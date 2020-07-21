using System;
using System.Collections.Generic;

namespace PhantomDragonStudio.TalentPoints
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Talent Point Container", menuName = "Phantom Dragon Studio/Talents/Talent Point Container", order = 0)]
    public class TalentPointContainer : ScriptableObject, ITalentPointContainer
    {
        public int TotalPointsAvailable { get => totalPointsAvailable; private set => totalPointsAvailable = value; }
        public int TotalPointsSpent { get => totalPointsSpent; private set => totalPointsSpent = value; }
        
        [SerializeField] private BaseTalentPoint[] talentPoints = default;
        [SerializeField] private int totalPointsAvailable;
        [SerializeField] private int totalPointsSpent;

        [NonSerialized] private List<BaseTalentPoint> instanceTalentPoints = new List<BaseTalentPoint>();

        public void Initialize(ICharacter character)
        {
            for (int i = 0; i < talentPoints.Length; i++)
            {
                if (talentPoints[i] != null && talentPoints.Length > 0)
                {
                    instanceTalentPoints.Add(ScriptableObject.Instantiate(talentPoints[i]));
                    instanceTalentPoints[i].Initialize(this, character);
                }
                else Debug.LogWarning(this.name + " has null talent points!");
            }
        } 

        public void IncreaseTalentPointLevel (int index)
        {
            if(TotalPointsAvailable != 0)
            {
                if (!instanceTalentPoints[index].IsMaxed())
                {
                    //Debug.Log("Increasing Talent Point Level for " + talentPoints[index].ToString());
                    TotalPointsSpent++;
                    TotalPointsAvailable--;
                    instanceTalentPoints[index].IncreaseLevel(1);
                }
                else 
                {
                    Debug.Log("Current Talent is already at max level!");
                }
            }
            else { Debug.Log("Not enough points available!"); }
        }

        public void AdjustPoints(int adjustmentAmount)
        {
            TotalPointsAvailable -= adjustmentAmount;
            totalPointsSpent += adjustmentAmount;
        }

        public ITalentPoint GetTalentPoint(int index)
        {
            return instanceTalentPoints[index];
        }

        public void ResetAllTalentPoints()
        {
            for (int i = 0; i < instanceTalentPoints.Count; i++)
            {
                if (instanceTalentPoints[i] != null)
                {
                    instanceTalentPoints[i].ResetCurrentLevel();
                }
            }
        }
    }
}