using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowLibs
{

    #region |- CLASSES -|

    public class Vector2D
    {
        public float X;
        public float Y;

        public Vector2D() { }

        public Vector2D( float _X, float _Y ) { X = _X; Y = _Y; }

        public Vector2D( Vector2D _Object ) { X = _Object.X; Y = _Object.Y; }

        public Vector2D( Vector3D _Object ) { X = _Object.X; Y = _Object.Y; }

        public Vector2D( Vector4D _Object ) { X = _Object.X; Y = _Object.Y; }

        public Vector2D Position { get { return this; } }

        public float GetLength( Vector2D _Object )
        {
            Vector2D Space = new Vector2D();

            Space.X = _Object.X - X;
            Space.Y = _Object.Y - Y;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) );
        }

        public float GetLength( float _X, float _Y )
        {
            Vector2D Space = new Vector2D();

            Space.X = _X - X;
            Space.Y = _Y - Y;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) );
        }
    }

    public class Vector3D
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3D() { }

        public Vector3D( float _X, float _Y, float _Z ) { X = _X; Y = _Y; Z = _Z; }

        public Vector3D( Vector3D _Object ) { X = _Object.X; Y = _Object.Y; Z = _Object.Z; }

        public Vector3D( Vector4D _Object ) { X = _Object.X; Y = _Object.Y; Z = _Object.Z; }

        public Vector3D Position { get { return this; } }

        public float GetLength( Vector3D _Object )
        {
            Vector3D Space = new Vector3D();

            Space.X = _Object.X - X;
            Space.Y = _Object.Y - Y;
            Space.Z = _Object.Z - Z;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) + ( Space.Z * Space.Z ) );
        }

        public float GetLength( float _X, float _Y, float _Z )
        {
            Vector3D Space = new Vector3D();

            Space.X = _X - X;
            Space.Y = _Y - Y;
            Space.Z = _Z - Z;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) + ( Space.Z * Space.Z ) );
        }

        public Vector3D Normalize( Vector3D _Space )
        {
            Vector3D norm = new Vector3D();

            float lenght = ( float )Math.Sqrt( ( _Space.X * _Space.X ) + ( _Space.Y * _Space.Y ) + ( _Space.Z * _Space.Z ) );

            norm.X = _Space.X / lenght;
            norm.Y = _Space.Y / lenght;
            norm.Z = _Space.Z / lenght;

            return norm;
        }
    }

    public class Vector4D
    {
        public float X;
        public float Y;
        public float Z;
        public float O;

        public Vector4D() { }

        public Vector4D( float _X, float _Y, float _Z, float _O ) { X = _X; Y = _Y; Z = _Z; O = _O; }

        public Vector4D( Vector4D _Object ) { X = _Object.X; Y = _Object.Y; Z = _Object.Z; O = _Object.O; }

        public Vector4D( Vector3D _Object ) { X = _Object.X; Y = _Object.Y; Z = _Object.Z; O = 0; }

        public Vector4D Position { get { return this; } }

        public float GetLength( Vector4D _Object )
        {
            Vector4D Space = new Vector4D();

            Space.X = _Object.X - X;
            Space.Y = _Object.Y - Y;
            Space.Z = _Object.Z - Z;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) + ( Space.Z * Space.Z ) );
        }

        public float GetLength( float _X, float _Y, float _Z )
        {
            Vector4D Space = new Vector4D();

            Space.X = _X - X;
            Space.Y = _Y - Y;
            Space.Z = _Z - Z;

            return ( float )Math.Sqrt( ( Space.X * Space.X ) + ( Space.Y * Space.Y ) + ( Space.Z * Space.Z ) );
        }
    }

    public class ViewAngle
    {
        public float Yaw;
        public float Pitch;

        public ViewAngle() { }

        public ViewAngle( float _Yaw, float _Pitch ) { Yaw = _Yaw; Pitch = _Pitch; }

        public ViewAngle GetViewAngle
        {
            get
            {
                return this;
            }
        }
    }

    #endregion


    #region |- STRUCTS -|

    public struct Matrix2x2
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;

        public float M21;
        public float M22;
        public float M23;
        public float M24;
    }

    public struct Matrix3x3
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;

        public float M21;
        public float M22;
        public float M23;
        public float M24;

        public float M31;
        public float M32;
        public float M33;
        public float M34;
    }

    public struct Matrix4x4
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;

        public float M21;
        public float M22;
        public float M23;
        public float M24;

        public float M31;
        public float M32;
        public float M33;
        public float M34;

        public float M41;
        public float M42;
        public float M43;
        public float M44;
    }

    public struct QuatTransform
    {
        public Vector4D TransAndScale; // SIZE 0x10
        public Vector4D Rotation; // SIZE 0x10
    } // Size 0x20

    public struct BoneTransformInfo
    {
        public Matrix4x4 Transform;
        public Vector4D Position;
    } // Size 0x50

    #endregion


    #region |- METHODES -|

    public class YT
    {
        public bool IsPtrValid( Int64 _Pointer )
        {
            if( _Pointer != 0 ) return true; else return false;
        }

        public Vector3D VectorNormalize( Vector3D _Space )
        {
            Vector3D norm = new Vector3D();

            float lenght = ( float )Math.Sqrt( ( _Space.X * _Space.X ) + ( _Space.Y * _Space.Y ) + ( _Space.Z * _Space.Z ) );

            norm.X = _Space.X / lenght;
            norm.Y = _Space.Y / lenght;
            norm.Z = _Space.Z / lenght;

            return norm;
        }

    } // YELLOW TOOLS

    #endregion
}
