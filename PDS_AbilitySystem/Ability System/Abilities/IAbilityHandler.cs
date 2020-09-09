﻿﻿using System.Collections.Generic;

  namespace PhantomDragonStudio.AbilitySystem
{
    public interface IAbilityHandler
    {
        Dictionary<int, IAbility> GetAbilities { get; }
        void AddAbility(int index, IAbility _ability);
        void RemoveAbility(int index);
        void LevelUpAbility(int index, int levelAmount);
        void CastAbility(int abilityIndex);
    }
}
