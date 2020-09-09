﻿﻿namespace PhantomDragonStudio.Matrix.Matrix
{
    public class MatrixTile : MonoBehaviour
    {
        public bool isVacant = true;

        private Color tileColor;
        private MeshRenderer myMeshRenderer;
        [SerializeField] private Vector3 distanceFromTerrain = default;

        void Awake()
        {
            myMeshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetToVacant()
        {
            this.isVacant = true;
            tileColor = Color.blue;
            myMeshRenderer.material.color = tileColor;
        }

        public void SetToNOTVacant()
        {
            this.isVacant = false;
            tileColor = Color.magenta;
            myMeshRenderer.material.color = tileColor;
        }

        public void RemoveUnusableTiles(LayerMask myLayerMask)
        {
            RaycastHit rcHit;
            Vector3 theRay = transform.TransformDirection(Vector3.down);

            if (Physics.Raycast(transform.position, theRay, out rcHit, Mathf.Infinity, myLayerMask))
            {
                print(rcHit.collider.name);
                var GroundDis = rcHit.distance;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, rcHit.normal);
                transform.position = (rcHit.point + distanceFromTerrain);
                if (this.transform.rotation != Quaternion.identity)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}