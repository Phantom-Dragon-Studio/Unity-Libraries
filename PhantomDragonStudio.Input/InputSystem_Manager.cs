﻿using UnityEngine;

namespace PhantomDragonStudio.Input
{
    public static class InputSystem_Manager
    {
        private static InputMap _inputMap;
        public static PointerDataProcessor PointerData { get; } = new PointerDataProcessor();
    
        public static InputMap Map
        {
            get
            {
                if(_inputMap == null)
                    Initialize();
                return _inputMap;
            }
        }

        private static void Initialize()
        {
            Debug.Log("PDS: Input System Initializing!");
            _inputMap = new InputMap();
            PointerData.Initialize();
        }
    }
}