using System;
using System.Collections.Generic;

namespace PhantomDragonStudio.TalentPoints
{
    [RequireComponent(typeof(MainCharacter))]
    public class TalentTreeHandler : MonoBehaviour
    {
        public ICharacter Character { get; private set; }
        [SerializeField] private TalentPointContainer[] talentPointTrees = default;
        
        [NonSerialized] private List<TalentPointContainer> trees = new List<TalentPointContainer>();
        void Start()
        {
            Character = GetComponent<Character>();
            
            for (int i = 0; i < talentPointTrees.Length; i++)
            {
                trees.Add(ScriptableObject.Instantiate(talentPointTrees[i]));
                trees[i].Initialize(Character);
            }
        }

        public void UpgradeTalent(int treeIndex, int talentIndex)
        {
            trees[treeIndex].IncreaseTalentPointLevel(talentIndex);
        }

        public void ResetTalentPointsInTree(int treeIndex)
        {
            trees[treeIndex].ResetAllTalentPoints();
        }
    }
}
