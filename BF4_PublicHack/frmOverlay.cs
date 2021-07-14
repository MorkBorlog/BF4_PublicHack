using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using YellowMemoryLib;
using YellowLibs;

namespace BF4_PublicHack
{
    public partial class frmOverlay : Form
    {
        #region |- DLL-IMPORTS -|

        [DllImport( "user32.dll" )]
        public static extern int GetKeyState( int vKey );

        [DllImport( "user32.dll" )]
        public static extern bool SetCursorPos( int X, int Y );

        #endregion

        Graphics Overlay;
        Settings HackSettings;
        YellowMemory Mem = new YellowMemory();
        HackManager Manager = new HackManager();

        public frmOverlay(Settings _HackSettings)
        {
            InitializeComponent();

            HackSettings = _HackSettings;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                new SecurityPermission( SecurityPermissionFlag.UnmanagedCode ).Demand();
                CreateParams CP = base.CreateParams;

                CP.ExStyle = CP.ExStyle | 0x00000020;

                return CP;
            }
        }

        private void frmOverlay_Load( object sender, EventArgs e )
        {
            Mem.AttackProcess( "bf4" );

            Overlay = pBoxOverlay.CreateGraphics();

            tGameChecker.Start();

            tESP.Start();
            if( HackSettings.Aimbot ) tAimbot.Start();
        }

        // Wenn das Spiel nicht gefunden wird, muss der Hack beendet werden!
        private void tGameChecker_Tick( object sender, EventArgs e )
        {
            if( !Mem.AttackProcess( "bf4" ) ) this.Close();

            // Damit wir nicht immer den gleichen Fenstertitel haben, ändern wir den einfach mal
            Random Rnd = new Random();
            this.Text = Rnd.Next().ToString();
        }

        private void tAimbot_Tick( object sender, EventArgs e )
        {
            try
            {
                if( HackSettings.NoRecoil ) Manager.NoRecoil();

                List<Player> Targets = Manager.SortPlayers_Crosshair( Manager.GetOnlyEnemys );

                int KeyResult = GetKeyState( 02 );

                if( ( KeyResult & 0x8000 ) > 0 && Manager.Client_Alive && Targets[ 0 ].Occluded == 0 )
                {
                    if( HackSettings.NoRecoil ) Manager.NoRecoil();

                    ViewAngle Aiming = Manager.GetAim( Targets[ 0 ] );

                    Manager.WriteAngle( Aiming.Yaw, Aiming.Pitch );

                    #region |-> TargetInfo

                    if( HackSettings.TargetInfo )
                    {
                        DrawString_White( Targets[ 0 ].Name, ( Manager.WindowWidth / 2 ) - 50, ( Manager.WindowHeight / 2 ) - 120, 20 );

                        DrawHealthBar_Background( ( Manager.WindowWidth / 2 ) - 50, ( Manager.WindowHeight / 2 ) - 80, 100, 20 );

                        float HealthBar_Value = 100 / 100 * Targets[ 0 ].Health;

                        DrawHealthBar_Health( ( Manager.WindowWidth / 2 ) - 50, ( Manager.WindowHeight / 2 ) - 80, ( int )HealthBar_Value, 20 );
                    }

                    #endregion

                    KeyResult = GetKeyState( 02 );
                }
            }
            catch { }
        }

        private void tESP_Tick( object sender, EventArgs e )
        {
            if( !Mem.AttackProcess( "bf4" ) ) this.Close();

            DrawBlackScreen();
            DrawString_White( "Yellow1982 by unknowncheats.me - Public free Hack V 0.4", 5, 5 );

            if(Manager.Client_Alive && !Manager.Client_InVehicle) DrawCrosshair();

            if( HackSettings.Enemy_ESP | HackSettings.Friend_ESP && Manager.Client_Alive)
            {
                List<Player> Players = new List<Player>();

                Players = Manager.GetAllPlayers;

                int Anzahl = Players.Count;

                #region |-> ESP

                // ESP
                for(int i = 0; i < Players.Count; i++)
                {
                    Vector3D Foot = Manager.WorldToScreen( Players[ i ].Position );
                    Vector3D Head = Manager.WorldToScreen_Head( Players[ i ].Position, Players[i].Pose );
                    Vector3D HeadBone = Manager.WorldToScreen( Players[ i ].HeadBone );

                    if( Head != null && Foot != null && Head.X != 0 && Head.Y != 0 && Foot.X != 0 && Foot.Y != 0 )
                    {
                        // MEIN TEAM
                        if( Players[ i ].Team == Manager.Client_Team && HackSettings.Friend_ESP)
                        {
                            float HeadToFoot = Foot.Y - Head.Y;
                            float BoxWidth = HeadToFoot / 2;
                            float X = Head.X - ( ( BoxWidth ) / 2 );
                            float CurrentHealth = BoxWidth / 100 * Players[i].Health;

                            DrawBox_Green( ( int )X, ( int )Head.Y, ( int )BoxWidth, ( int )HeadToFoot );

                            if(HackSettings.Friend_Lines && !Manager.Client_InVehicle)
                            {
                                if( Players[ i ].Distance_3D < 100 ) DrawLine_Green( Manager.WindowWidth / 2, Manager.WindowHeight, Foot.X, Foot.Y );
                            }

                            if( HackSettings.Friend_Distance && !Manager.Client_InVehicle )
                            {
                                DrawString_White( string.Format("{0:0}", Players[i].Distance_3D), ( int )Foot.X, ( int )Foot.Y );
                            }

                            if( HackSettings.Friend_Healthbar && Players[ i ].Distance_3D < 50 )
                            {
                                DrawHealthBar_Background( ( int )X, ( int )Head.Y - 10, ( int )BoxWidth, 5 );
                                DrawHealthBar_Health( ( int )X, ( int )Head.Y - 10, ( int )CurrentHealth, 5 );
                            }
                        }

                        // ANDERES TEAM
                        if( Players[ i ].Team != Manager.Client_Team && HackSettings.Enemy_ESP)
                        {
                            float HeadToFoot = Foot.Y - Head.Y;
                            float BoxWidth = HeadToFoot / 2;
                            float X = Head.X - ( ( BoxWidth ) / 2 );
                            float CurrentHealth = BoxWidth / 100 * Players[ i ].Health;

                            DrawBox_Yellow( ( int )X, ( int )Head.Y, ( int )BoxWidth, ( int )HeadToFoot );
                            if( Players[ i ].Occluded == 0 ) DrawBox_Red( ( int )X, ( int )Head.Y, ( int )BoxWidth, ( int )HeadToFoot );

                            if( HackSettings.Enemy_Lines && !Manager.Client_InVehicle )
                            {
                                if( Players[ i ].Occluded == 1) DrawLine_Yellow( Manager.WindowWidth / 2, Manager.WindowHeight, Foot.X, Foot.Y );
                                if( Players[ i ].Occluded == 0) DrawLine_Red( Manager.WindowWidth / 2, Manager.WindowHeight, Foot.X, Foot.Y );
                            }

                            if( HackSettings.Friend_Distance && !Manager.Client_InVehicle )
                            {
                                DrawString_White( string.Format( "{0:0}", Players[ i ].Distance_3D ), ( int )Foot.X, ( int )Foot.Y );
                            }

                            if(HackSettings.Enemy_Healthbar && Players[i].Distance_3D < 50)
                            {
                                DrawHealthBar_Background( ( int )X, ( int )Head.Y - 10, ( int )BoxWidth, 5 );
                                DrawHealthBar_Health( ( int )X, ( int )Head.Y - 10, ( int )CurrentHealth, 5 );
                            }
                        }
                    }
                }

                #endregion

            }
        }


        #region |- DRAW METHODES -|

        public void DrawBlackScreen()
        {
            Rectangle BlackScreen = new Rectangle();
            SolidBrush BlackBrush = new SolidBrush( Color.Black );

            BlackScreen.X = 0;
            BlackScreen.Y = 0;
            BlackScreen.Width = this.Width;
            BlackScreen.Height = this.Height;

            Overlay.FillRectangle( BlackBrush, BlackScreen );
        }


        #region HEALTHBAR

        public void DrawHealthBar_Background( int _X, int _Y, int _Width, int _Height )
        {
            SolidBrush GrayBrush = new SolidBrush( Color.Gray );

            Overlay.FillRectangle( GrayBrush, _X, _Y, _Width, _Height );
        }

        public void DrawHealthBar_Health( int _X, int _Y, int _Width, int _Height )
        {
            SolidBrush GreenBrush = new SolidBrush( Color.Green );

            Overlay.FillRectangle( GreenBrush, _X, _Y, _Width, _Height );
        }

        #endregion


        #region BOX

        public void DrawBox_Green( int _X, int _Y, int _Width, int _Height )
        {
            Overlay.DrawRectangle( Pens.Green, _X, _Y, _Width, _Height );
        }

        public void DrawBox_Yellow( int _X, int _Y, int _Width, int _Height )
        {
            Overlay.DrawRectangle( Pens.Yellow, _X, _Y, _Width, _Height );
        }

        public void DrawBox_Red( int _X, int _Y, int _Width, int _Height )
        {
            Overlay.DrawRectangle( Pens.Red, _X, _Y, _Width, _Height );
        }

        #endregion


        #region STRINGS

        public void DrawString_White( string _String, int _X, int _Y, int _Size = 10 )
        {
            Font OverlayText = new Font( "Arial", _Size );

            Overlay.DrawString( _String, OverlayText, Brushes.White, _X, _Y );
        }

        #endregion


        #region LINES

        public void DrawLine_Red( int _xFrom, int _yFrom, float _xTo, float _yTo )
        {
            Overlay.DrawLine( Pens.Red, _xFrom, _yFrom, _xTo, _yTo );
        }

        public void DrawLine_Green( int _xFrom, int _yFrom, float _xTo, float _yTo )
        {
            Overlay.DrawLine( Pens.Green, _xFrom, _yFrom, _xTo, _yTo );
        }

        public void DrawLine_Yellow( int _xFrom, int _yFrom, float _xTo, float _yTo )
        {
            Overlay.DrawLine( Pens.Yellow, _xFrom, _yFrom, _xTo, _yTo );
        }

        #endregion


        #region CROSSHAIR

        public void DrawCrosshair()
        {
            // Horizont Line
            Overlay.DrawLine( Pens.Red, Manager.CrosshairX - 10, Manager.CrosshairY, Manager.CrosshairX + 10, Manager.CrosshairY );

            // Vertikale Line
            Overlay.DrawLine( Pens.Red, Manager.CrosshairX, Manager.CrosshairY - 10, Manager.CrosshairX, Manager.CrosshairY + 10 );
        }

        #endregion

        #endregion
    }
}
