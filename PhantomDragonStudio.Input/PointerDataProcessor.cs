using UnityEngine;

namespace PhantomDragonStudio.Input
{
    [System.Serializable]
    public class PointerDataProcessor
    {
        public Vector2 CurrentMousePosition => currentMousePosition;
        
        private InputMap _inputMap;
        private Vector2 currentMousePosition;

        public void Initialize()
        {
            _inputMap = InputSystem_Manager.Map;

            _inputMap.Player.Pointer.Enable();
            _inputMap.Player.Pointer.performed += ctx => currentMousePosition = ctx.ReadValue<Vector2>();
        }
    }
}