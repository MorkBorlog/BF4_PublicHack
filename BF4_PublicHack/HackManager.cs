using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Meine Bibliotheken
using YellowMemoryLib;
using YellowLibs;
using YellowBF4Offsets;

namespace BF4_PublicHack
{
    public class HackManager
    {
        YellowMemory Mem = new YellowMemory();
        GameRenderView RenderView = new GameRenderView();
        YT YTools = new YT();
        
        const int MaxPlayers = 70;

        public HackManager() { Mem.AttackProcess( "bf4" ); }


        #region |- STATIC INFORMATIONS -|

        #region DXRenderer

        public Int64 pDXRenderer
        {
            get
            {
                return Mem.ReadInt64( sAddresses.DXRenderer );
            }
        }

        public Int64 pScreen
        {
            get
            {
                if(pDXRenderer != 0)
                {
                    return Mem.ReadInt64( pDXRenderer + sOffsets.DXRenderer.ClassScreen );
                }

                return 0;
            }
        }

        public int WindowWidth
        {
            get
            {
                if(pScreen != 0)
                {
                    return Mem.ReadInt32( pScreen + sOffsets.DXRenderer.Screen.Width );
                }

                return 0;
            }
        }

        public int WindowHeight
        {
            get
            {
                if( pScreen != 0 )
                {
                    return Mem.ReadInt32( pScreen + sOffsets.DXRenderer.Screen.Height );
                }

                return 0;
            }
        }

        public int CrosshairX
        {
            get
            {
                return WindowWidth / 2;
            }
        }

        public int CrosshairY
        {
            get
            {
                return WindowHeight / 2;
            }
        }

        #endregion

        public Int64 pClientGameContext
        {
            get
            {
                return Mem.ReadInt64( sAddresses.ClientGameContext );
            }
        }

        public Int64 pClientPlayerManager
        {
            get
            {
                return Mem.ReadInt64( pClientGameContext + sOffsets.ClassClientPlayerManager );
            }
        }

        public Int64 pLocalPlayer
        {
            get
            {
                return Mem.ReadInt64( pClientPlayerManager + sOffsets.ClientPlayerManger.LocalPlayer );
            }
        }

        public Int64 pPlayerArray
        {
            get
            {
                return Mem.ReadInt64( pClientPlayerManager + sOffsets.ClientPlayerManger.PlayerArray );
            }
        }
        
        #endregion


        #region |- CLIENT PLAYER INFORMATIONS -|

        public string Client_Name
        {
            get
            {
                return Mem.ReadString( pLocalPlayer + sOffsets.Player.Name, 20 );
            }
        }

        public Int32 Client_Team
        {
            get
            {
                return Mem.ReadInt32( pLocalPlayer + sOffsets.Player.Team );
            }
        }

        public float Client_Health
        {
            get
            {
                Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

                if( pSoldier != 0 )
                {
                    Int64 pHealth = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassHealth );

                    if( pHealth != 0 )
                    {
                        return Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.CurPlayerHealth );
                    }
                }

                return 0;
            }
        }

        public float Client_MaxHealth
        {
            get
            {
                Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

                if( pSoldier != 0 )
                {
                    Int64 pHealth = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassHealth );

                    if( pHealth != 0 )
                    {
                        return Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.MaxPlayerHealth );
                    }
                }

                return 0;
            }
        }

        public float Client_VehicleHealth
        {
            get
            {
                Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

                if( pSoldier != 0 )
                {
                    Int64 pHealth = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassHealth );

                    if( pHealth != 0 )
                    {
                        return Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.CurVehicleHealth );
                    }
                }

                return 0;
            }
        }

        public bool Client_Alive
        {
            get
            {
                if( Client_Health == 0 && Client_VehicleHealth == 0 ) return false; return true;
            }
        }

        public bool Client_InVehicle
        {
            get
            {
                if( Client_Health == 0 && Client_MaxHealth == 0 && Client_VehicleHealth > 0 ) return true; else return false;
            }
        }

        public Vector3D Client_Position
        {
            get
            {
                Vector3D Position = new Vector3D();

                Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

                if( pSoldier != 0 )
                {
                    Int64 pClientPosition = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassPlayerPosition );

                    if( pClientPosition != 0 )
                    {
                        Position.X = Mem.ReadFloat( pClientPosition + sOffsets.Player.Soldier.PlayerPosition.XPlayer );
                        Position.Y = Mem.ReadFloat( pClientPosition + sOffsets.Player.Soldier.PlayerPosition.YPlayer );
                        Position.Z = Mem.ReadFloat( pClientPosition + sOffsets.Player.Soldier.PlayerPosition.ZPlayer );
                    }
                }

                return Position;
            }
        }

        public Int32 Client_Pose
        {
            get
            {
                Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

                if( pSoldier != 0 )
                {
                    if( pSoldier != 0 ) return Mem.ReadInt32( pSoldier + sOffsets.Player.Soldier.SoldierPose );
                }

                return -1;
            }
        }

        public Vector3D Client_Position_Eye
        {
            get
            {
                Matrix4x4 mTmp = RenderView.GetViewMatrixInverse();

                Vector3D tmp = new Vector3D();

                tmp.X = mTmp.M41;
                tmp.Y = mTmp.M42;
                tmp.Z = mTmp.M43;

                return tmp;
            }
        }

        #endregion


        #region |- ONLINE PLAYER INFORMATIONS -|

        public List<Int64> GetPlayerAddresses
        {
            get
            {
                List<Int64> Addresses = new List<Int64>();

                for( int i = 0; i < MaxPlayers; i++ )
                {
                    Int64 CurAddress = Mem.ReadInt64( pPlayerArray + ( i * 0x8 ) ); // 0x8 ist die Hexdezimale größe von Int64

                    // Wenn die gefundene Addresse existiert und nicht unseres Client Players entspricht, dann mitnehmen.
                    if(CurAddress != 0 && CurAddress != pLocalPlayer)
                    {
                        Addresses.Add( CurAddress );
                    }
                }

                return Addresses;
            }
        }

        public List<Player> GetAllPlayers
        {
            get
            {
                List<Int64> Addresses = GetPlayerAddresses;
                List<Player> AllPlayers = new List<Player>();

                for( int i = 0; i < Addresses.Count; i++ )
                {
                    Int64 pSoldier = Mem.ReadInt64( Addresses[ i ] + sOffsets.Player.ClassSoldier );

                    if(pSoldier != 0)
                    {
                        Int64 pHealth = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassHealth );
                        Int64 pPosition = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassPlayerPosition );
                        Int64 pRageDoll = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassClientRagDollComponent );

                        if(pHealth != 0 && pPosition != 0 && pRageDoll != 0)
                        {
                            Int64 pUpdateResult = Mem.ReadInt64( pRageDoll + ( 0x88 + 0x28 ) );

                            if(pUpdateResult != 0)
                            {
                                Player CurPlayer = new Player();

                                CurPlayer.Name = Mem.ReadString( Addresses[ i ] + sOffsets.Player.Name, 20 );
                                CurPlayer.Team = Mem.ReadInt32( Addresses[ i ] + sOffsets.Player.Team );

                                CurPlayer.Occluded = Mem.ReadByte( pSoldier + sOffsets.Player.Soldier.IsOccluded );
                                CurPlayer.Pose = Mem.ReadInt32( pSoldier + sOffsets.Player.Soldier.SoldierPose );

                                CurPlayer.Health = Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.CurPlayerHealth );
                                CurPlayer.MaxHealth = Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.MaxPlayerHealth );
                                CurPlayer.VechicleHealth = Mem.ReadFloat( pHealth + sOffsets.Player.Soldier.PlayerHealth.CurVehicleHealth );

                                CurPlayer.X = Mem.ReadFloat( pPosition + sOffsets.Player.Soldier.PlayerPosition.XPlayer );
                                CurPlayer.Y = Mem.ReadFloat( pPosition + sOffsets.Player.Soldier.PlayerPosition.YPlayer );
                                CurPlayer.Z = Mem.ReadFloat( pPosition + sOffsets.Player.Soldier.PlayerPosition.ZPlayer );

                                CurPlayer.HeadBone.X = Mem.ReadFloat( pUpdateResult + 0xD00 );
                                CurPlayer.HeadBone.Y = Mem.ReadFloat( pUpdateResult + 0xD04 );
                                CurPlayer.HeadBone.Z = Mem.ReadFloat( pUpdateResult + 0xD08 );

                                CurPlayer.Distance_3D = Client_Position.GetLength( CurPlayer.Position );
                                CurPlayer.Distance_Crosshair = Distance_CrosshairToW2S( CurPlayer );

                                AllPlayers.Add( CurPlayer );
                            }
                        }
                    }
                }

                return AllPlayers;
            }
        }

        public List<Player> GetOnlyEnemys
        {
            get
            {
                List<Player> AllPlayers = GetAllPlayers;
                List<Player> OnlyEnemys = new List<Player>();

                for(int i = 0; i < AllPlayers.Count; i++)
                {
                    if( AllPlayers[ i ].Team != Client_Team ) OnlyEnemys.Add( AllPlayers[ i ] );
                }

                return OnlyEnemys;
            }
        }

        public List<Player> GetOnlyFriends
        {
            get
            {
                List<Player> AllPlayers = GetAllPlayers;
                List<Player> OnlyFriends = new List<Player>();

                for( int i = 0; i < AllPlayers.Count; i++ )
                {
                    if( AllPlayers[ i ].Team == Client_Team ) OnlyFriends.Add( AllPlayers[ i ] );
                }

                return OnlyFriends;
            }
        }

        #endregion


        #region |- GLOBAL METHODS -|

        public float Distance_CrosshairToW2S( Player _TargetPlayer )
        {
            // Setzen wir mal einen ScreenVector
            Vector3D ScreenVector = new Vector3D();

            // Nun ermitteln wir die Bildschirm Position des angegebenen Spielers.
            ScreenVector = WorldToScreen( _TargetPlayer.HeadBone );

            // Üblegt selbst :P
            float X = ScreenVector.X > CrosshairX ? ScreenVector.X - CrosshairX : CrosshairX - ScreenVector.X;
            float Y = ScreenVector.Y > CrosshairX ? ScreenVector.Y - CrosshairX : CrosshairY - ScreenVector.Y;

            return ( float )Math.Sqrt( X * X + Y * Y );
        }

        public List<Player> SortPlayers_3D( List<Player> _Players )
        {
            var Sorted = _Players.OrderBy( a => a.Distance_3D ).ToList();

            return Sorted;
        }

        public List<Player> SortPlayers_Crosshair( List<Player> _Players )
        {
            var Sorted = _Players.OrderBy( a => a.Distance_Crosshair ).ToList();

            return Sorted;
        }

        public Vector3D WorldToScreen( Vector3D _Enemy )
        {
            // Eine Matrix erstellen und auslesen
            Matrix4x4 ViewMatrix = RenderView.GetViewMatrix();

            // Den Rückgabe Vector erstellen.
            Vector3D tmp = new Vector3D();

            // Distanz ermitteln.
            float ScreenW = ( ViewMatrix.M14 * _Enemy.X ) + ( ViewMatrix.M24 * _Enemy.Y ) + ( ViewMatrix.M34 * _Enemy.Z + ViewMatrix.M44 );

            // Ist der Gegner nicht vor einem, dann einen Leeren Vetor zurückgeben.
            if( ScreenW < 0.0001f )
            {
                return tmp;
            }

            // Horizontale Position ermitteln
            float ScreenX = ( ViewMatrix.M11 * _Enemy.X ) + ( ViewMatrix.M21 * _Enemy.Y ) + ( ViewMatrix.M31 * _Enemy.Z + ViewMatrix.M41 );

            // Vertikale Position ermitteln
            float ScreenY = ( ViewMatrix.M12 * _Enemy.X ) + ( ViewMatrix.M22 * _Enemy.Y ) + ( ViewMatrix.M32 * _Enemy.Z + ViewMatrix.M42 );

            // Bildschirmbreite mal Ermittelte X Position durch Distanz
            tmp.X = CrosshairX + CrosshairX * ScreenX / ScreenW;

            // Bildschirmhöhe mal Ermittelte Y Position durch Distanz
            tmp.Y = CrosshairY - CrosshairY * ScreenY / ScreenW;

            // Z Wird zum Platzhalter der Distanz
            tmp.Z = ScreenW;

            return tmp;
        }

        public Vector3D WorldToScreen_Head( Vector3D _Enemy, int _Pose = 0 )
        {
            // Eine Matrix erstellen und auslesen
            Matrix4x4 ViewMatrix = RenderView.GetViewMatrix();

            // Den Rückgabe Vector erstellen.
            Vector3D tmp = new Vector3D();

            float HeadHeight = _Enemy.Y;


            #region HeadHeight

            // STEHT
            if(_Pose == 0)
            {
                HeadHeight += 1.8f;
            }

            // KNIEHT
            if(_Pose == 1)
            {
                HeadHeight += 1.1f;
            }

            // LIEGT
            if(_Pose == 2)
            {
                HeadHeight += 0.7f;
            }

            #endregion


            // Distanz ermitteln.
            float ScreenW = ( ViewMatrix.M14 * _Enemy.X ) + ( ViewMatrix.M24 * HeadHeight ) + ( ViewMatrix.M34 * _Enemy.Z + ViewMatrix.M44 );

            // Ist der Gegner nicht vor einem, dann einen Leeren Vetor zurückgeben.
            if( ScreenW < 0.0001f )
            {
                return tmp;
            }

            // Horizontale Position ermitteln
            float ScreenX = ( ViewMatrix.M11 * _Enemy.X ) + ( ViewMatrix.M21 * HeadHeight ) + ( ViewMatrix.M31 * _Enemy.Z + ViewMatrix.M41 );

            // Vertikale Position ermitteln
            float ScreenY = ( ViewMatrix.M12 * _Enemy.X ) + ( ViewMatrix.M22 * HeadHeight ) + ( ViewMatrix.M32 * _Enemy.Z + ViewMatrix.M42 );

            // Bildschirmbreite mal Ermittelte X Position durch Distanz
            tmp.X = CrosshairX + CrosshairX * ScreenX / ScreenW;

            // Bildschirmhöhe mal Ermittelte Y Position durch Distanz
            tmp.Y = CrosshairY - CrosshairY * ScreenY / ScreenW;

            // Z Wird zum Platzhalter der Distanz
            tmp.Z = ScreenW;

            return tmp;
        }

        public void WriteAngle( float _Yaw, float _Pitch )
        {
            Int64 pBase = Mem.ReadInt64( sAddresses.ViewAngles );
            Int64 pOffset1 = Mem.ReadInt64( pBase + sOffsets.ViewAngles.Offset1 );
            Int64 pOffset2 = Mem.ReadInt64( pOffset1 + sOffsets.ViewAngles.Offset2 );

            Mem.WriteFloat( pOffset2 + sOffsets.ViewAngles.Yaw, _Yaw );
            Mem.WriteFloat( pOffset2 + sOffsets.ViewAngles.Pitch, _Pitch );
        }

        public ViewAngle GetAim( Player _EnemyPlayer )
        {
            // Get Space Vector
            Vector3D Space = new Vector3D();

            float Gravity = BulletGravity();
            float Speed = BulletSpeed();
            float Time = _EnemyPlayer.Distance_3D / Speed;
            float Drop = Math.Abs( 0.5f * Gravity * Time * Time );

            float NewY = _EnemyPlayer.HeadBone.Y + Drop;

            Space.X = _EnemyPlayer.HeadBone.X - Client_Position_Eye.X;
            Space.Y = NewY - Client_Position_Eye.Y;
            Space.Z = _EnemyPlayer.HeadBone.Z - Client_Position_Eye.Z;

            Space = YTools.VectorNormalize( Space );

            ViewAngle Aiming = new ViewAngle();

            Aiming.Yaw = ( float )-Math.Atan2( Space.X, Space.Z );
            Aiming.Pitch = ( float )Math.Atan2( Space.Y, Math.Sqrt( ( Space.X * Space.X ) + ( Space.Z * Space.Z ) ) );

            return Aiming;
        }

        public void NoRecoil()
        {
            byte NoRecoilValue = 0;

            Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );
            
            if(pSoldier != 0)
            {
                Int64 pClientWeaponComponent = Mem.ReadInt64( pSoldier + sOffsets.Player.Soldier.ClassClientSoldierWeaponsComponent );

                if(pClientWeaponComponent != 0)
                {
                    Int64 pWeaponHandle = Mem.ReadInt64( pClientWeaponComponent + sOffsets.Player.Soldier.ClientSoldierWeaponsComponent.ClassClientAnimatedSoldierWeaponHandler );
                    Int32 ActiveSlot = Mem.ReadInt32( pClientWeaponComponent + sOffsets.Player.Soldier.ClientSoldierWeaponsComponent.ActiveSlot );

                    if(pWeaponHandle != 0)
                    {
                        Int64 pSoldierWeapon = Mem.ReadInt64( pWeaponHandle + ActiveSlot * 0x8 );

                        if(pSoldierWeapon != 0)
                        {
                            Int64 pCorrectedFiring = Mem.ReadInt64( pSoldierWeapon + sOffsets.Player.Soldier.ClientSoldierWeaponsComponent.ClientAnimatedSoldierWeaponHandler.ClientSoldierWeapon.ClassWeaponFiring );

                            if(pCorrectedFiring != 0)
                            {
                                Int64 pWeaponSway = Mem.ReadInt64( pCorrectedFiring + sOffsets.Player.Soldier.ClientSoldierWeaponsComponent.ClientAnimatedSoldierWeaponHandler.ClientSoldierWeapon.WeaponFiring.WeaponSway );

                                if(pWeaponSway != 0)
                                {
                                    if(ActiveSlot == 0 | ActiveSlot == 1)
                                    {
                                        Mem.WriteInt32( pWeaponSway + 0x1E8, NoRecoilValue );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public float BulletGravity()
        {
            Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

            Int64 pWeaponComponent = Mem.ReadInt64( pSoldier + 0x550 );

            if( pWeaponComponent != 0 )
            {
                int pWeaponSlot = Mem.ReadInt32( pWeaponComponent + 0x9A8 );
                Int64 pWeaponHandler = Mem.ReadInt64( pWeaponComponent + 0x7A0 );

                if( pWeaponHandler != 0 )
                {
                    Int64 pSoldierWeapon = Mem.ReadInt64( pWeaponHandler + ( pWeaponSlot * 0x8 ) );

                    if( pSoldierWeapon != 0 )
                    {
                        Int64 pCorrectedFiring = Mem.ReadInt64( pSoldierWeapon + 0x49C0 );

                        if( pCorrectedFiring != 0 )
                        {
                            Int64 pWeaponFiringData = Mem.ReadInt64( pCorrectedFiring + 0x128 );

                            if( pWeaponFiringData != 0 )
                            {
                                Int64 pFireData = Mem.ReadInt64( pWeaponFiringData + 0x10 );

                                if( pFireData != 0 )
                                {
                                    float BulletSpeed = Mem.ReadFloat( pFireData + 0x88 );
                                    Int64 pProjectileData = Mem.ReadInt64( pFireData + 0xB0 );

                                    if( pProjectileData != 0 )
                                    {
                                        return Mem.ReadFloat( pProjectileData + 0x130 ); // GRAVITY
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        public float BulletSpeed()
        {
            Int64 pSoldier = Mem.ReadInt64( pLocalPlayer + sOffsets.Player.ClassSoldier );

            Int64 pWeaponComponent = Mem.ReadInt64( pSoldier + 0x550 );

            if( pWeaponComponent != 0 )
            {
                int pWeaponSlot = Mem.ReadInt32( pWeaponComponent + 0x9A8 );
                Int64 pWeaponHandler = Mem.ReadInt64( pWeaponComponent + 0x7A0 );

                if( pWeaponHandler != 0 )
                {
                    Int64 pSoldierWeapon = Mem.ReadInt64( pWeaponHandler + ( pWeaponSlot * 0x8 ) );

                    if( pSoldierWeapon != 0 )
                    {
                        Int64 pCorrectedFiring = Mem.ReadInt64( pSoldierWeapon + 0x49C0 );

                        if( pCorrectedFiring != 0 )
                        {
                            Int64 pWeaponFiringData = Mem.ReadInt64( pCorrectedFiring + 0x128 );

                            if( pWeaponFiringData != 0 )
                            {
                                Int64 pFireData = Mem.ReadInt64( pWeaponFiringData + 0x10 );

                                if( pFireData != 0 )
                                {
                                    return Mem.ReadFloat( pFireData + 0x88 ); // BULLETSPEED
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        #endregion
    }
}
