using PhantomDragonStudio.TalentPoints;
using PhantomDragonStudio.UnitSystem.Attributes;
using UnityEngine;

namespace App.Talent_Points
{
    [CreateAssetMenu(fileName = "New Talent Point", menuName = "Phantom Dragon Studio/Talents/Attribute Bonus Talent", order = 2)]
    public class AttributeBonus : BaseTalentPoint
    {
        [Header("Attribute Details")] [SerializeField]
        private AttributeType attributeType = default;
        [SerializeField] private float bonusPerPoint = default;
        private float value;

        public override void PerformFunctionality()
        {
            value = bonusPerPoint * CurrentLevel;
            Debug.Log("Increasing " + attributeType + " by " + value);
            character.CharacteristicController.Attributes.UpdateAttribute(attributeType, value);
        }

        public override void StopFunctionality()
        {
            character.CharacteristicController.Attributes.UpdateAttribute(attributeType, -value);
        }
    }
}