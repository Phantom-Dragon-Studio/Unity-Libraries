using UnityEngine;
using UnityEngine.Serialization;

namespace PhantomDragonStudio.AbilitySystem
{
    [System.Serializable]
    public class AbilityInfo
    {
        [SerializeField] private int currentLevel = default;
        [SerializeField] private int maxLevel = default;
        [Tooltip("Base Cooldown to use for level 1 of ability. We then apply the cooldown modifier per level.")]
        [SerializeField] private float cooldownTime = default;
        [FormerlySerializedAs("cooldownModifier")]
        [Tooltip("This value will be assumed to be negative; however, if you would like to INCREASE the cooldown rate per level, provide a negative number.")]
        [SerializeField] private float cooldownChangePerLevel = default;
        public int CurrentLevel { get => currentLevel; internal set => currentLevel = value; }
        public int MaxLevel { get => maxLevel; internal set => maxLevel = value; }
        public float CooldownTime { get => cooldownTime; internal set => cooldownTime = value; }
        public float CooldownChangePerLevel { get => cooldownChangePerLevel; internal set => cooldownChangePerLevel = value; }
    }
}