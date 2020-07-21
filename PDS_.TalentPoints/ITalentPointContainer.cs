﻿﻿namespace PhantomDragonStudio.TalentPoints
{
    public interface ITalentPointContainer
    {
        ITalentPoint GetTalentPoint(int index);
        int TotalPointsAvailable { get; }
        int TotalPointsSpent { get; }
        void AdjustPoints(int adjustmentAmount);
    }
}
