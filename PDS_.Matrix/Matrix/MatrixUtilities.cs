using UnityEngine;

namespace PhantomDragonStudio.Matrix
{
    public static class MatrixUtilities
    {
        private static Vector3 _newMatrixPos;
        private static double _gridPosX, _gridPosY, _gridPosZ;

        public static Vector3 SnapPlacement(Vector3 position)
        {
            _gridPosX = Mathf.Round(position.x * 4) / 4;
            _gridPosY = Mathf.Round(position.y * 4) / 4;
            _gridPosZ = Mathf.Round(position.z * 4) / 4;

            _newMatrixPos.x = (float) _gridPosX;
            _newMatrixPos.y = (float) _gridPosY;
            _newMatrixPos.z = (float) _gridPosZ;

            //Debug.Log("Snapping newly created item at Grid Position: " + _newMatrixPos.ToString());

            return _newMatrixPos;
        }
    
        public static RaycastHit[] DoBoxCast (Vector3 recievedPosition, Vector3 _v3Extents, LayerMask _layerMask)
        {
            RaycastHit[] hits = Physics.BoxCastAll(
                recievedPosition,
                _v3Extents,
                Vector3.down,
                Quaternion.identity,
                Mathf.Infinity,
                _layerMask
            );
            return hits;
        }
    }
}