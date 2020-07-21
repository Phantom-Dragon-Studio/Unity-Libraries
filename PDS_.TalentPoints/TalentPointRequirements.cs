namespace PhantomDragonStudio.TalentPoints
{
    [System.Serializable]
    public class TalentPointRequirements : ITalentPointRequirements
    {
        [SerializeField] private int requiredPointsInTree = default;
        [SerializeField] private BaseTalentPoint[] requiredTalentPoints = default;

        public bool Validate(ITalentPoint owner)
        {
            //Debug.Log("Validating " + owner.GeneralTalentInfo.Name);

            if (requiredPointsInTree > owner.Container.TotalPointsSpent) return false;
            if (requiredTalentPoints.Length == 0) return true;

            for (int i = 0; i < requiredTalentPoints.Length; i++)
            {
                if (requiredTalentPoints[i] != null)
                {
                    if(requiredTalentPoints[i].IsMaxed())
                        if (i == requiredTalentPoints.Length - 1)
                            return true;
                    continue;
                }
                Debug.Log("Null talent point requirement for " + owner.ToString());
                return true;
            }
            return false;
        }
    }
}