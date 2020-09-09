﻿﻿namespace PhantomDragonStudio.Combat
{
    public interface IHealthMechanics : IHealable, IDamageable, IKillable
    {
        CharacterHealth Health { get; }
    }
}
