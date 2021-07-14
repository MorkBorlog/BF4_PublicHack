using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YellowLibs;

// Written by Yellow1982 for Unknowncheats.me

namespace YellowMemoryLib
{
    public class YellowMemoryApi
    {
        public const uint PROCESS_VM_READ = ( 0x0010 );
        public const uint PROCESS_VM_WRITE = ( 0x0020 );
        public const uint PROCESS_VM_OPERATION = ( 0x0008 );
        public const uint PAGE_READWRITE = 0x0004;

        [DllImport( "kernel32.dll" )]
        public static extern IntPtr OpenProcess( UInt32 dwAccess, bool inherit, int pid );

        [DllImport( "kernel32.dll" )]
        public static extern bool CloseHandle( IntPtr handle );

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool ReadProcessMemory( IntPtr hProcess, Int64 lpBaseAddress, [In, Out] byte[] lpBuffer, UInt64 dwSize, out IntPtr lpNumberOfBytesRead );

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool ReadProcessMemory( IntPtr hProcess, Int64 lpBaseAddress, [Out, MarshalAs( UnmanagedType.AsAny )] object lpBuffer, UInt64 dwSize, out IntPtr lpNumberOfBytesRead );

        [DllImport( "kernel32.dll" )]
        public static extern bool WriteProcessMemory( IntPtr hProcess, Int64 lpBaseAddress, [In, Out] byte[] lpBuffer, UInt64 dwSize, out IntPtr lpNumberOfBytesWritten );

        [DllImport( "kernel32", SetLastError = true )]
        public static extern IntPtr VirtualAllocEx( IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, uint flAllocationType, uint flProtect );

        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool VirtualProtectEx( IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, uint flNewProtect, out uint lpflOldProtect );
    }

    public class YellowMemory
    {
        private Process CurProcess;
        private IntPtr ProcessHandle;
        private string ProcessName;
        private int ProcessID;
        public IntPtr BaseModule;

        // Destruktor
        ~YellowMemory() { if( ProcessHandle != IntPtr.Zero ) YellowMemoryApi.CloseHandle( ProcessHandle ); }

        // Get Process for work
        public bool AttackProcess( string _ProcessName )
        {
            try
            {
                Process[] Processes = Process.GetProcessesByName( _ProcessName );

                if( Processes.Length > 0 )
                {
                    BaseModule = Processes[ 0 ].MainModule.BaseAddress;
                    CurProcess = Processes[ 0 ];
                    ProcessID = Processes[ 0 ].Id;
                    ProcessName = _ProcessName;

                    ProcessHandle = YellowMemoryApi.OpenProcess( YellowMemoryApi.PROCESS_VM_READ | YellowMemoryApi.PROCESS_VM_WRITE | YellowMemoryApi.PROCESS_VM_OPERATION, false, ProcessID );

                    if( ProcessHandle != IntPtr.Zero )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // If Process attacked
        public bool IsOpen()
        {
            if( ProcessName == string.Empty )
            {
                return false;
            }
            else
            {
                if( AttackProcess( ProcessName ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        #region |- READ MEMORY -|

        // Read Object
        public object ReadObject( Int64 _lpBaseAddress, uint _Size )
        {
            object[] Buffer = new object[ _Size ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, _Size, out ByteRead );

            return Buffer;
        }

        // Read Byte
        public byte ReadByte( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ sizeof( byte ) ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, sizeof( byte ), out ByteRead );

            return Buffer[ 0 ];
        }

        // Read Int32
        public Int32 ReadInt32( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ 4 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, 4, out ByteRead );

            return BitConverter.ToInt32( Buffer, 0 );
        }

        // Read UInt32
        public UInt32 ReadUInt32( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ 4 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, 4, out ByteRead );

            return BitConverter.ToUInt32( Buffer, 0 );
        }

        // Read Int64
        public Int64 ReadInt64( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ 8 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, 8, out ByteRead );

            return BitConverter.ToInt64( Buffer, 0 );
        }

        // Read UInt64
        public UInt64 ReadUInt64( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ 8 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, 8, out ByteRead );

            return BitConverter.ToUInt64( Buffer, 0 );
        }

        // Read Int64
        public float ReadFloat( Int64 _lpBaseAddress )
        {
            byte[] Buffer = new byte[ sizeof( float ) ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, sizeof( float ), out ByteRead );

            return BitConverter.ToSingle( Buffer, 0 );
        }

        // Read String
        public string ReadString( Int64 _lpBaseAddress, UInt64 _Size )
        {
            byte[] Buffer = new byte[ _Size ];
            IntPtr BytesRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, _Size, out BytesRead );

            return Encoding.UTF8.GetString( Buffer );
        }

        // Read Matrix4x4
        public Matrix4x4 ReadMatrix4x4( Int64 _lpBaseAddress )
        {
            Matrix4x4 tmp = new Matrix4x4();

            byte[] Buffer = new byte[ 64 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _lpBaseAddress, Buffer, 64, out ByteRead );

            tmp.M11 = BitConverter.ToSingle( Buffer, ( 0 * 4 ) );
            tmp.M12 = BitConverter.ToSingle( Buffer, ( 1 * 4 ) );
            tmp.M13 = BitConverter.ToSingle( Buffer, ( 2 * 4 ) );
            tmp.M14 = BitConverter.ToSingle( Buffer, ( 3 * 4 ) );

            tmp.M21 = BitConverter.ToSingle( Buffer, ( 4 * 4 ) );
            tmp.M22 = BitConverter.ToSingle( Buffer, ( 5 * 4 ) );
            tmp.M23 = BitConverter.ToSingle( Buffer, ( 6 * 4 ) );
            tmp.M24 = BitConverter.ToSingle( Buffer, ( 7 * 4 ) );

            tmp.M31 = BitConverter.ToSingle( Buffer, ( 8 * 4 ) );
            tmp.M32 = BitConverter.ToSingle( Buffer, ( 9 * 4 ) );
            tmp.M33 = BitConverter.ToSingle( Buffer, ( 10 * 4 ) );
            tmp.M34 = BitConverter.ToSingle( Buffer, ( 11 * 4 ) );

            tmp.M41 = BitConverter.ToSingle( Buffer, ( 12 * 4 ) );
            tmp.M42 = BitConverter.ToSingle( Buffer, ( 13 * 4 ) );
            tmp.M43 = BitConverter.ToSingle( Buffer, ( 14 * 4 ) );
            tmp.M44 = BitConverter.ToSingle( Buffer, ( 15 * 4 ) );

            return tmp;
        }

        // Read QuatTransform
        public QuatTransform ReadQuatTransform( Int64 _QuatTransformAddress )
        {
            QuatTransform QT = new QuatTransform();

            byte[] Buffer = new byte[ 20 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _QuatTransformAddress, Buffer, 20, out ByteRead );

            Vector4D TransAndScale = new Vector4D();
            Vector4D Rotation = new Vector4D();

            TransAndScale.X = BitConverter.ToSingle( Buffer, ( 0 * 4 ) );
            TransAndScale.Y = BitConverter.ToSingle( Buffer, ( 1 * 4 ) );
            TransAndScale.Z = BitConverter.ToSingle( Buffer, ( 2 * 4 ) );
            TransAndScale.O = BitConverter.ToSingle( Buffer, ( 3 * 4 ) );

            Rotation.X = BitConverter.ToSingle( Buffer, ( 4 * 4 ) );
            Rotation.Y = BitConverter.ToSingle( Buffer, ( 5 * 4 ) );
            Rotation.Z = BitConverter.ToSingle( Buffer, ( 6 * 4 ) );
            Rotation.O = BitConverter.ToSingle( Buffer, ( 7 * 4 ) );

            QT.TransAndScale = TransAndScale;
            QT.Rotation = Rotation;

            return QT;
        }

        // Read BoneTransformInfo
        public BoneTransformInfo ReadBoneTransformInfo( Int64 _BoneTransformAddress )
        {
            BoneTransformInfo Info = new BoneTransformInfo();

            Info.Transform = ReadMatrix4x4( _BoneTransformAddress );

            byte[] Buffer = new byte[ 10 ];
            IntPtr ByteRead;

            YellowMemoryApi.ReadProcessMemory( ProcessHandle, _BoneTransformAddress + 0x40, Buffer, 10, out ByteRead );

            // MATRIX4x4 -> START
            //BitConverter.ToSingle(Buffer, (0 * 4)); // BASE
            //BitConverter.ToSingle(Buffer, (1 * 4)); // +0x4
            //BitConverter.ToSingle(Buffer, (2 * 4)); // +0x8
            //BitConverter.ToSingle(Buffer, (3 * 4)); // +0xC
            //BitConverter.ToSingle(Buffer, (4 * 4)); // +0x10
            //BitConverter.ToSingle(Buffer, (5 * 4)); // +0x14
            //BitConverter.ToSingle(Buffer, (6 * 4)); // +0x18
            //BitConverter.ToSingle(Buffer, (7 * 4)); // +0x1C
            //BitConverter.ToSingle(Buffer, (8 * 4)); // +0x20
            //BitConverter.ToSingle(Buffer, (9 * 4)); // +0x24
            //BitConverter.ToSingle(Buffer, (10 * 4)); // +0x28
            //BitConverter.ToSingle(Buffer, (11 * 4)); // +0x2C
            //BitConverter.ToSingle(Buffer, (12 * 4)); // +0x30
            //BitConverter.ToSingle(Buffer, (13 * 4)); // +0x34
            //BitConverter.ToSingle(Buffer, (14 * 4)); // +0x38
            //BitConverter.ToSingle(Buffer, (15 * 4)); // +0x3C
            // MATRIX4x4 -> END

            Info.Position.X = BitConverter.ToSingle( Buffer, ( 16 * 4 ) ); // +0x40
            Info.Position.Y = BitConverter.ToSingle( Buffer, ( 17 * 4 ) ); // +0x44
            Info.Position.Z = BitConverter.ToSingle( Buffer, ( 18 * 4 ) ); // +0x48
            Info.Position.O = BitConverter.ToSingle( Buffer, ( 19 * 4 ) ); // +0x4C

            return Info;
        }

        #endregion


        #region |- WRITE MEMORY -|

        public void WriteMemory( Int64 MemoryAddress, byte[] Buffer )
        {
            uint oldProtect;
            YellowMemoryApi.VirtualProtectEx( ProcessHandle, ( IntPtr )MemoryAddress, ( uint )Buffer.Length, YellowMemoryApi.PAGE_READWRITE, out oldProtect );

            IntPtr ptrBytesWritten;
            YellowMemoryApi.WriteProcessMemory( ProcessHandle, MemoryAddress, Buffer, ( uint )Buffer.Length, out ptrBytesWritten );
        }

        public void WriteByte( Int64 _lpBaseAddress, byte _Value )
        {
            byte[] Buffer = { _Value };

            WriteMemory( _lpBaseAddress, Buffer );
        }

        public void WriteInt32( Int64 _lpBaseAddress, int _Value )
        {
            byte[] Buffer = BitConverter.GetBytes( _Value );

            WriteMemory( _lpBaseAddress, Buffer );
        }

        public void WriteUInt32( Int64 _lpBaseAddress, uint _Value )
        {
            byte[] Buffer = BitConverter.GetBytes( _Value );

            WriteMemory( _lpBaseAddress, Buffer );
        }

        public void WriteFloat( Int64 _lpBaseAddress, float _Value )
        {
            byte[] Buffer = BitConverter.GetBytes( _Value );

            WriteMemory( _lpBaseAddress, Buffer );
        }


        #endregion
    }
}