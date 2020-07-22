using System;
using PhantomDragonStudio.Core.Utilities;
using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.Characters;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Rogue;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Warrior;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Wizard;

namespace PhantomDragonStudio.UnitSystem.Data
{
    public class CharacterSheet : ICharacterSheet
    {
        public static CharacterSheet CreateInstance()
        {
            return new CharacterSheet();
        }

        //General Information
        private Label objectInformation = new Label();
        private Character prefab;
        private CharacterLeagueType characterLeagueType = default;
        private float agility = -1;
        private float strength = -1;
        private float wisdom = -1;
        private float endurance = -1;

        /// <summary>
        ///  Main Data Container for characters
        ///  Attributes do not have direct getters. They are loaded into an array and sent as a whole.
        ///  The SO is setup in this manner to allow explicit attribute base values to be assigned without needing to write a custom inspector.
        /// </summary>


        public ICharacterAttribute[] Attributes { get; } = 
            new ICharacterAttribute[Enum.GetNames(typeof(AttributeType)).Length];

        public Label Label => objectInformation;
        public ICharacterLeague League { get; private set; }

        public Character Prefab
        {
            get => prefab;
            set => value = prefab;
        }

        public float Agility
        {
            get => agility;
            set => agility = value;
        }

        public float Strength
        {
            get => strength;
            set => strength = value;
        }

        public float Wisdom
        {
            get => wisdom;
            set => wisdom = value;
        }

        public float Endurance
        {
            get => endurance;
            set => endurance = value;
        }


        #region Initialization

        public void Initialize()
        {
            Logger.Say("Initializing ICharacterSheet for " + Label.Name);
            Attributes[0] = CharacterAttributeFactory.Create(AttributeType._None, 0f);
            Attributes[1] = CharacterAttributeFactory.Create(AttributeType.Agility, Agility);
            Attributes[2] = CharacterAttributeFactory.Create(AttributeType.Strength, Strength);
            Attributes[3] = CharacterAttributeFactory.Create(AttributeType.Wisdom, Wisdom);
            Attributes[4] = CharacterAttributeFactory.Create(AttributeType.Endurance, Endurance);
            League = CreateLeague();
        }

        private ICharacterLeague CreateLeague()
        {
            switch (characterLeagueType)
            {
                case CharacterLeagueType.Rogue:
                {
                    return new Rogue();
                }
                case CharacterLeagueType.Warrior:
                {
                    return new Warrior();
                }
                case CharacterLeagueType.Wizard:
                {
                    return new Wizard();
                }
                default:
                {
                    Logger.SayWarning(Label.Name +
                                      " has an empty class type selected and therefore will have a null CharacterLeague.");
                    return null;
                }
            }
        }

        #endregion
    }
}