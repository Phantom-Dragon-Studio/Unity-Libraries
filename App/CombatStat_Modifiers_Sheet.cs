using System.Collections.Generic;
using PhantomDragonStudio.UnitSystem.CombatStats;
using UnityEngine;

namespace App
{
    [CreateAssetMenu(fileName = "New Combat Stat Modifiers Sheet", menuName = "Phantom Dragon Studio/Settings Modifiers Sheet", order = 0)]
    public class CombatStat_Modifiers_Sheet : ScriptableObject
    {
        [Range(0,5)]
        [SerializeField] public float primaryAttributeGlobalModifier = default;
        [Range(0,5)]
        [SerializeField] public float secondaryAttributeGlobalModifier = default;

        //Accessed via dictionary key.
        [Header("Combat Stats")]
        [Range(0, 0.5f)] [SerializeField] private float criticalStrikeChance_perAttributePoint = default;
        [Range(0, 0.5f)] [SerializeField] private float dodgeChance_perAttributePoint = default;
        [Range(0, 10)] [SerializeField] private float physicalDamage_perAttributePoint = default;
        [Range(0, 10)] [SerializeField] private float magicalDamage_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float attackSpeed_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float movementSpeed_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float physicalDefense_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float magicalDefense_perAttributePoint = default;
        [Range(0, 25)] [SerializeField] private float maxHealth_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float healthRegen_perAttributePoint = default;
        [Range(0, 25)] [SerializeField] private float maxM_E_F_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float M_E_F_Regen_perAttributePoint = default;
        [Range(0, 25)] [SerializeField] private float maxStamina_perAttributePoint = default;
        [Range(0, 3)] [SerializeField] private float staminaRegen_perAttributePoint = default;


        public Dictionary<CombatStatType, float> Settings { get; private set; } = new Dictionary<CombatStatType, float>();

        void OnEnable()
        {
            Settings.Add(CombatStatType.CriticalStrikeChance, criticalStrikeChance_perAttributePoint);
            Settings.Add(CombatStatType.DodgeChance, dodgeChance_perAttributePoint);
            Settings.Add(CombatStatType.PhysicalDamage, physicalDamage_perAttributePoint);
            Settings.Add(CombatStatType.MagicalDamage, magicalDamage_perAttributePoint);
            Settings.Add(CombatStatType.AttackSpeed, attackSpeed_perAttributePoint);
            Settings.Add(CombatStatType.MovementSpeed, movementSpeed_perAttributePoint);
            Settings.Add(CombatStatType.PhysicalDefense, physicalDefense_perAttributePoint);
            Settings.Add(CombatStatType.MagicDefense, magicalDefense_perAttributePoint);
            Settings.Add(CombatStatType.MaxHealth, maxHealth_perAttributePoint);
            Settings.Add(CombatStatType.Health_RegenerationRate, healthRegen_perAttributePoint);
            Settings.Add(CombatStatType.M_E_F_Base, maxM_E_F_perAttributePoint);
            Settings.Add(CombatStatType.M_E_F_RegenerationRate, M_E_F_Regen_perAttributePoint);
            Settings.Add(CombatStatType.Stamina_Base, maxStamina_perAttributePoint);
            Settings.Add(CombatStatType.Stamina_RegenerationRate, staminaRegen_perAttributePoint);
        }
    }
}
