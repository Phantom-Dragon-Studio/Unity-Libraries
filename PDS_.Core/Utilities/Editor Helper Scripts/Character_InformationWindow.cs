namespace PhantomDragonStudio.Core.Utilities.Editor_Helper_Scripts
{
    public class Character_InformationWindow : MonoBehaviour
    {
        Character character;
        ICharacteristicController characteristicController;

        [ShowOnly] [SerializeField] private CharacterLeagueType leagueType;

        [Header("Combat Manager Attribute Settings")]
        [ShowOnly] [SerializeField] float primaryAttributeEffectiveness;
        [ShowOnly] [SerializeField] float secondaryAttributeEffectiveness;

        [Header("Attributes")]
        [ShowOnly] [SerializeField] float agility;
        [ShowOnly] [SerializeField] float strength;
        [ShowOnly] [SerializeField] float wisdom;
        [ShowOnly] [SerializeField] float endurance;

        [Header("Combat Stats")]
        [ShowOnly] [SerializeField] float criticalStrikeChance;
        [ShowOnly] [SerializeField] float dodgeChance;
        [ShowOnly] [SerializeField] float physicalDamage;
        [ShowOnly] [SerializeField] float magicalDamage;
        [ShowOnly] [SerializeField] float movementSpeed;
        [ShowOnly] [SerializeField] float attackSpeed;
        [ShowOnly] [SerializeField] float magicDefense;
        [ShowOnly] [SerializeField] float physicalDefense;

        [Header("Health")]
        [ShowOnly] [SerializeField] float maxHealthSTAT;
        [ShowOnly] [SerializeField] float maxHealthVALUE;
        [ShowOnly] [SerializeField] float currentHealth;
        [ShowOnly] [SerializeField] float healthRegen;

        [Header("Mana / Energy / Focus")]
        [ShowOnly] [SerializeField] float M_E_F_Base;
        [ShowOnly] [SerializeField] float M_E_F_Regen;

        [Header("Stamina")]
        [ShowOnly] [SerializeField] float staminaBase;
        [ShowOnly] [SerializeField] float staminaRegen;

        [Header("Resistances")] 
        [ShowOnly] [SerializeField] float elementalResistanceFire;
        [ShowOnly] [SerializeField] float elementalResistanceWater;
        [ShowOnly] [SerializeField] float elementalResistanceEarth;
        [ShowOnly] [SerializeField] float elementalResistanceWind;
        [ShowOnly] [SerializeField] float elementalResistanceLightning;
        [ShowOnly] [SerializeField] float elementalResistanceDivine;
        [ShowOnly] [SerializeField] float elementalResistanceDark;
        [ShowOnly] [SerializeField] float elementalResistanceArcane;

        void Start()
        {
            character = GetComponent<Character>();
            characteristicController = character.CharacteristicController;
            leagueType = character.CharacterSheet.League.LeagueType;
            primaryAttributeEffectiveness = CharacteristicsManager.Instance.LeagueSettings[character.CharacterSheet.League.LeagueType].primaryAttributeGlobalModifier;
            secondaryAttributeEffectiveness = CharacteristicsManager.Instance.LeagueSettings[character.CharacterSheet.League.LeagueType].secondaryAttributeGlobalModifier;
        }

        void Update()
        {
            //Attributes
            agility = characteristicController.Attributes.Agility.AttributeInfo.value;
            strength = characteristicController.Attributes.Strength.AttributeInfo.value;
            wisdom = characteristicController.Attributes.Wisdom.AttributeInfo.value;
            endurance = characteristicController.Attributes.Endurance.AttributeInfo.value;

            //Combat Stats
            criticalStrikeChance = characteristicController.CombatStats.CriticalStrikeChance.Value;
            dodgeChance = characteristicController.CombatStats.DodgeChance.Value;
            attackSpeed = characteristicController.CombatStats.AttackSpeed.Value;
            movementSpeed = characteristicController.CombatStats.MovementSpeed.Value;
            physicalDamage = characteristicController.CombatStats.PhysicalDamage.Value;
            magicalDamage = characteristicController.CombatStats.MagicalDamage.Value;
            physicalDefense = characteristicController.CombatStats.PhysicalDefense.Value;
            magicDefense = characteristicController.CombatStats.MagicDefense.Value;

            currentHealth = character.Health.CurrentHealth;
            maxHealthVALUE = character.Health.MaxHealth;
            maxHealthSTAT = characteristicController.CombatStats.MaxHealth.Value;
            healthRegen = characteristicController.CombatStats.HealthRegen.Value;

            M_E_F_Base = characteristicController.CombatStats.M_E_F_Base.Value;
            M_E_F_Regen = characteristicController.CombatStats.M_E_F_Regen.Value;

            staminaBase = characteristicController.CombatStats.StaminaBase.Value;
            staminaRegen = characteristicController.CombatStats.StaminaRegen.Value;

            //Elemental Resistances
            // elementalResistanceFire = ElementalResistances.GetResistanceByType(ElementalEffectType.Fire).ResistanceInfo.value;
            // elementalResistanceWater = ElementalResistances.GetResistanceByType(ElementalEffectType.Water).ResistanceInfo.value;
            // elementalResistanceEarth = ElementalResistances.GetResistanceByType(ElementalEffectType.Earth).ResistanceInfo.value;
            // elementalResistanceWind = ElementalResistances.GetResistanceByType(ElementalEffectType.Wind).ResistanceInfo.value;
            // elementalResistanceLightning = ElementalResistances.GetResistanceByType(ElementalEffectType.Lightning).ResistanceInfo.value;
            // elementalResistanceDivine = ElementalResistances.GetResistanceByType(ElementalEffectType.Divine).ResistanceInfo.value;
            // elementalResistanceDark = ElementalResistances.GetResistanceByType(ElementalEffectType.Dark).ResistanceInfo.value;
            // elementalResistanceArcane = ElementalResistances.GetResistanceByType(ElementalEffectType.Arcane).ResistanceInfo.value;
        }
    }
}