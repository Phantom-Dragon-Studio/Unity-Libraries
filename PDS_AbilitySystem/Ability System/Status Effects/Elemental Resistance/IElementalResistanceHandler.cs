﻿﻿namespace PhantomDragonStudio.AbilitySystem
{
    public interface IElementalResistanceHandler
    {
        IElementalResistance Fire { get; }
        IElementalResistance Water { get; }
        IElementalResistance Earth { get; }
        IElementalResistance Wind  { get; }
        IElementalResistance Lightning { get; }
        IElementalResistance Divine { get; }
        IElementalResistance Dark { get; }
        IElementalResistance Arcane { get; }

        void AddResistance(ElementalType typeToAdd, float amount);
        void UpdateIndividualResistance(ElementalType typeToUpdate, float amount);
        IElementalResistance GetResistanceByType(ElementalType typeToCheck);
    }
}
