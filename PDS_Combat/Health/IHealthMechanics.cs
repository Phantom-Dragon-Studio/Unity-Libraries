﻿﻿namespace PhantomDragonStudio.Combat.Health
{
    public interface IHealthMechanics : IHealable, IDamageable, IKillable
    {
        CharacterHealth Health { get; }
    }
}
