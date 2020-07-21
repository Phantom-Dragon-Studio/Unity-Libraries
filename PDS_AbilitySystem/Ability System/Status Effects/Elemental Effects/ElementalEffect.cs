﻿﻿using UnityEngine;

namespace PhantomDragonStudio.Ability_System
{
    [System.Serializable]
    public class ElementalEffect : IElementalType
    {
        
        [SerializeField] private float amount;
        public float Amount { get; set; }
        public ElementalType ElementalType { get; }

        public ElementalEffect(ElementalType type )
        {
            ElementalType = type;
        }
    
        public override string ToString()
        {
            return ElementalType.ToString() + ": " + Amount.ToString();
        }
    }
}
