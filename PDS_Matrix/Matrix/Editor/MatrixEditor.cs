namespace PhantomDragonStudio.Matrix.Matrix.Editor
{
    [CustomEditor(typeof(Matrix))]
    public class MatrixEditor : Editor
    {
        private bool isCurrentlyGenerated;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Matrix _matrix = (Matrix)target;

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate Matrix"))
            {
                if (isCurrentlyGenerated)
                {
                    RemoveTiles(_matrix);
                }
                _matrix.DrawGrid();
                isCurrentlyGenerated = true;
            }
        
            if (GUILayout.Button("Remove All Attached Tiles"))
            {
                RemoveTiles(_matrix);
            }
            GUILayout.EndHorizontal();
        }

        private void RemoveTiles(Matrix _matrix)
        {
            MatrixTile[] tilesToRemove = _matrix.transform.GetComponentsInChildren<MatrixTile>();

            for (int i = 0; i < tilesToRemove.Length; i++)
            {
                DestroyImmediate(tilesToRemove[i].gameObject);
            }
            isCurrentlyGenerated = false;
        }
    }

}