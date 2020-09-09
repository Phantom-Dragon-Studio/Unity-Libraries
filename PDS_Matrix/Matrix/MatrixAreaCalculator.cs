using System.Collections.Generic;

namespace PhantomDragonStudio.Matrix.Matrix
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MatrixAreaCalculator : MonoBehaviour
    {
        public LayerMask _layerMask;

        private Vector3 _v3Extents;
        private MatrixTile _checkTile;
        private RaycastHit[] hits;
        private List<MatrixTile> checkedTiles = new List<MatrixTile>();

        void Start()
        {
            CheckPlacementArea(this.transform);
        }

        public bool CheckPlacementArea(Transform _passedTransform)
        {
            checkedTiles.Clear();

            _v3Extents = _passedTransform.localScale / 4;

            hits = MatrixUtilities.DoBoxCast(_passedTransform.position, _v3Extents * 2, _layerMask);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject != this.gameObject)
                {
                    _checkTile = hits[i].collider.GetComponent<MatrixTile>();
                    if (!_checkTile || _checkTile.isVacant == false)
                    {
                        break;
                    }
                    else if (_checkTile.isVacant == true)
                    {
                        checkedTiles.Add(_checkTile);
                    }
                }
                else
                {
                    print("I hit myself...");
                }
            }

            if (checkedTiles.Count == hits.Length && checkedTiles.Count != 0)
            {
                for (int i = 0; i < checkedTiles.Count; i++)
                {
                    _checkTile = checkedTiles[i];
                    _checkTile.SetToNOTVacant();
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}