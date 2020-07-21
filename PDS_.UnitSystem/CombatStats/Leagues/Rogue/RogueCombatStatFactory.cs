﻿﻿/// <summary>
//  Initializes the type and value of all combat stats for the rogue. Assigning unique listeners
//  If you want to change WHAT attributes' each combat stat listens to, you may do that inside this function below.
//  Note: Here we have implemented the null implementation pattern. You subscribe to an empty attributes' events
//  only if you wish to not utilize the secondary attribute for that given stat.
/// </summary>

  using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Rogue
{
    public static class RogueCombatStatFactory
    {
        public static ICombatStat[] Create(ICharacteristicController characteristicController, ICombatStat[] combatStats)
        {
            combatStats[0] = new RogueStat(CombatStatType.CriticalStrikeChance,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Strength); 

            combatStats[1] = new RogueStat(CombatStatType.DodgeChance,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Strength);

            combatStats[2] = new RogueStat(CombatStatType.PhysicalDamage,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Agility);

            combatStats[3] = new RogueStat(CombatStatType.MagicalDamage,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.Agility);

            combatStats[4] = new RogueStat(CombatStatType.MovementSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[5] = new RogueStat(CombatStatType.AttackSpeed,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.NULL);

            combatStats[6] = new RogueStat(CombatStatType.PhysicalDefense,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.NULL); 

            combatStats[7] = new RogueStat(CombatStatType.MagicDefense,
                characteristicController.Attributes.Wisdom,
                characteristicController.Attributes.NULL);

            combatStats[8] = new RogueStat(CombatStatType.MaxHealth,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Endurance);

            combatStats[9] = new RogueStat(CombatStatType.Health_RegenerationRate,
                characteristicController.Attributes.Strength,
                characteristicController.Attributes.Endurance);

            combatStats[10] = new RogueStat(CombatStatType.M_E_F_Base,
                characteristicController.Attributes.Endurance,
                characteristicController.Attributes.NULL);

            combatStats[11] = new RogueStat(CombatStatType.M_E_F_RegenerationRate,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            combatStats[12] = new RogueStat(CombatStatType.Stamina_Base,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            combatStats[13] = new RogueStat(CombatStatType.Stamina_RegenerationRate,
                characteristicController.Attributes.Agility,
                characteristicController.Attributes.Endurance);

            return combatStats;
        }
    }
} 