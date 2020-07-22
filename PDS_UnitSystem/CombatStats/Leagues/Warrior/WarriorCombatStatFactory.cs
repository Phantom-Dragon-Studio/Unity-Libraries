﻿﻿using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Warrior
{
    /// <summary>
    //  Initializes the type and value of all combat stats for the rogue. Assigning unique listerners
    //  If you want to change WHAT attibutes each combat stat listens to, you may do that inside this function below.
    //  Note: Here we have implemented the null implementation pattern. You subscribe to an empty attibute's events
    //  only if you wish to not utilize the secondary attribute for that given stat.
    /// </summary>
    public static class WarriorCombatStatFactory
    {
        public static ICombatStat[] Create(ICharacteristicController characteristicController, ICombatStat[] combatStats)
        {
            combatStats[0] = new WarriorStat(CombatStatType.CriticalStrikeChance,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[1] = new WarriorStat(CombatStatType.DodgeChance,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[2] = new WarriorStat(CombatStatType.PhysicalDamage,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Agility);

            combatStats[3] = new WarriorStat(CombatStatType.MagicalDamage,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Agility);

            combatStats[4] = new WarriorStat(CombatStatType.MovementSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[5] = new WarriorStat(CombatStatType.AttackSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[6] = new WarriorStat(CombatStatType.PhysicalDefense,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.Strength);

            combatStats[7] = new WarriorStat(CombatStatType.MagicDefense,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.NULL);

            combatStats[8] = new WarriorStat(CombatStatType.MaxHealth,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.Strength);

            combatStats[9] = new WarriorStat(CombatStatType.Health_RegenerationRate,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Wisdom);

            combatStats[10] = new WarriorStat(CombatStatType.M_E_F_Base,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.NULL);

            combatStats[11] = new WarriorStat(CombatStatType.M_E_F_RegenerationRate,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            combatStats[12] = new WarriorStat(CombatStatType.Stamina_Base,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.NULL);

            combatStats[13] = new WarriorStat(CombatStatType.Stamina_RegenerationRate,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.NULL);

            return combatStats;
        }
    }
}