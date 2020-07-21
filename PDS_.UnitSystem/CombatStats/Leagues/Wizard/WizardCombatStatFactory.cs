﻿﻿using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Wizard
{
    /// <summary>
    //  Initializes the type and value of all combat stats for the rogue. Assigning unique listerners
    //  If you want to change WHAT attibutes each combat stat listens to, you may do that inside this function below.
    //  Note: Here we have implemented the null implementation pattern. You subscribe to an empty attibute's events
    //  only if you wish to not utilize the secondary attribute for that given stat.
    /// </summary>
    public static class WizardCombatStatFactory
    {
        public static ICombatStat[] Create(ICharacteristicController characteristicController, ICombatStat[] combatStats)
        {

            combatStats[0] = new WizardStat(CombatStatType.CriticalStrikeChance,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Agility);

            combatStats[1] = new WizardStat(CombatStatType.DodgeChance,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Agility);

            combatStats[2] = new WizardStat(CombatStatType.PhysicalDamage,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Agility);

            combatStats[3] = new WizardStat(CombatStatType.MagicalDamage,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Agility);

            combatStats[4] = new WizardStat(CombatStatType.MovementSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[5] = new WizardStat(CombatStatType.AttackSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[6] = new WizardStat(CombatStatType.PhysicalDefense,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.Strength);

            combatStats[7] = new WizardStat(CombatStatType.MagicDefense,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.NULL);

            combatStats[8] = new WizardStat(CombatStatType.MaxHealth,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Endurance);

            combatStats[9] = new WizardStat(CombatStatType.Health_RegenerationRate,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Endurance);

            combatStats[10] = new WizardStat(CombatStatType.M_E_F_Base,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Endurance);

            combatStats[11] = new WizardStat(CombatStatType.M_E_F_RegenerationRate,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Endurance);

            combatStats[12] = new WizardStat(CombatStatType.Stamina_Base,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            combatStats[13] = new WizardStat(CombatStatType.Stamina_RegenerationRate,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            return combatStats;
        }
    }
}