﻿﻿namespace PhantomDragonStudio.Combat
{
    public interface ITargetable
    {
        Vector3 GetPosition { get; }
        GameObject GetGameObject { get; }
        Transform Transform { get; }
        int GetInstanceID();
        void Damage(float amount);
        void Heal(float amount);
        Vector3 CurrentVelocity();
    }
}
