

//Use this script as a purely editorial tool to snap things to an imaginary grid. Useful for repeatedly placing objects in specific locations and formations.
//This was used for manual tile placement but is no longer necessary. You may delete this script without consequences if you so desire to do.

namespace PhantomDragonStudio.Core.Utilities.Editor_Helper_Scripts
{
    [ExecuteInEditMode]
    public static class EditorSnapToGrid
    {
        private Vector3 newGridPos;

        public static  Vector3 SnapPlacement(Vector3 position)
        {
            double gridPosX = Mathf.Round(position.x * 4) / 4;
            double gridPosY = Mathf.Round(position.y * 4) / 4;
            double gridPosZ = Mathf.Round(position.z * 4) / 4;

            newGridPos.x = (float)gridPosX;
            newGridPos.y = (float)gridPosY;
            newGridPos.z = (float)gridPosZ;

            return newGridPos;
        }
    }
}
