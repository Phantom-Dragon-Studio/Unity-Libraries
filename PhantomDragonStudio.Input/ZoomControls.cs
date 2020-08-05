using UnityEngine;

namespace PhantomDragonStudio.Input
{
    [System.Serializable]
    public class ZoomControls
    {
        [Range(0f, 5f)] [SerializeField] private float zoomSensitivity = 1f;
        [Range(0f, 5f)] [SerializeField] private float zoomSpeedModifier = 1f;
        private InputMap _inputMap;
        private Vector2 scroll;
        public Vector2 Scroll => scroll;

        public void Initialize()
        {
            _inputMap = InputSystem_Manager.Map;

            _inputMap.Player.Zoom.Enable();
            _inputMap.Player.Zoom.performed += ctx => scroll = ctx.ReadValue<Vector2>() * zoomSensitivity;
            _inputMap.Player.Zoom.canceled += ctx => scroll = Vector2.zero;
        }

        public Vector3 BuildZoom(Vector3 position, float maxDistance, float minDistance)
        {
            var newPos = new Vector3(
                position.x,
                position.y,
                Mathf.Clamp(position.z + Scroll.y * zoomSpeedModifier, maxDistance, minDistance));
            return newPos;
        }
    }
}