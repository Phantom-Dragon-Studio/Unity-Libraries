using System;

namespace  PhantomDragonStudio.Combat
{
    public class ProjectileCollisionEventArgs : EventArgs
    {
        public int GOInstanceID { get; }
        public float Value { get; }
        public ProjectileCollisionEventArgs(int instanceID, float value)
        {
            // Debug.Log("new Projectile Collision Event Args Created.... " + instanceID.ToString());
            GOInstanceID = instanceID;
            Value = value;
        }
    }
}