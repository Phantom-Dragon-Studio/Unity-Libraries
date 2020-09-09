﻿﻿using System.Collections.Generic;

  namespace PhantomDragonStudio.AbilitySystem
{
    /// <summary>
    /// This class manages all Elemental Resistances on a given unit. This hsould allow for easy management of the effects each unit has on it at the time.
    /// Allowing for stacking of effects.
    /// </summary>

    public class ElementalResistanceHandler : IElementalResistanceHandler
    {
        private const float DefaultValue = 10f; //TODO Default to 0
        private Dictionary<ElementalType, IElementalResistance> ResistanceTypes { get; } = new Dictionary<ElementalType, IElementalResistance>();

        public IElementalResistance Fire => ResistanceTypes[ElementalType.Fire];
        public IElementalResistance Water => ResistanceTypes[ElementalType.Water];
        public IElementalResistance Earth => ResistanceTypes[ElementalType.Earth];
        public IElementalResistance Wind => ResistanceTypes[ElementalType.Wind];
        public IElementalResistance Lightning => ResistanceTypes[ElementalType.Lightning];
        public IElementalResistance Divine => ResistanceTypes[ElementalType.Divine];
        public IElementalResistance Dark => ResistanceTypes[ElementalType.Dark];
        public IElementalResistance Arcane => ResistanceTypes[ElementalType.Arcane];

        public void AddResistance(ElementalType typeToAdd, float amount)
        {
            if (!ResistanceTypes.ContainsKey(typeToAdd))
                ResistanceTypes.Add(typeToAdd, ElementalResistanceFactory.Create(typeToAdd, amount));
        }

        public void UpdateIndividualResistance(ElementalType typeToUpdate, float amount)
        {
            ResistanceTypes[typeToUpdate].ResistanceInfo.value += amount;
        }

        public IElementalResistance GetResistanceByType(ElementalType typeToCheck)
        {
            if (ResistanceTypes.ContainsKey(typeToCheck)) 
                return ResistanceTypes[typeToCheck];
            AddResistance(typeToCheck, DefaultValue);
            return ResistanceTypes[typeToCheck];
        }
    }
} 