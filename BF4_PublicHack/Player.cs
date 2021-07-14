using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowLibs;

namespace BF4_PublicHack
{
    public class Player : Vector3D
    {
        public string Name;
        public float Health;
        public float MaxHealth;
        public float VechicleHealth;
        public float VehicleMaxHealth;
        public float Distance_Crosshair;
        public float Distance_3D;
        public Int32 Pose;
        public Int32 Team;
        public byte Occluded;
        public Vector3D HeadBone = new Vector3D();
    }
}
