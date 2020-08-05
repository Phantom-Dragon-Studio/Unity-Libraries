﻿using UnityEngine;

namespace PhantomDragonStudio.Input
{
    [System.Serializable]
    public class MovementProcessor
    {
        [Range(0.1f, 5f)][SerializeField] private float movementSensitivity  = 1f;
        [Range(0f, 5f)][SerializeField] private float movementSpeedModifier = 1f;
        [SerializeField] private InputMap _inputMap;
        public Vector2 RawInput { get; private set; }
        public bool ShiftModifier { get; private set; }
        public float ModifedPanSpeed => movementSpeedModifier;

        public void Initialize()
        {
            if (_inputMap == null)
                _inputMap = new InputMap();

            _inputMap.Player.Move.Enable();
            _inputMap.Player.ShiftModifier.Enable();
            _inputMap.Player.ShiftModifier.performed += ctx => ShiftModifier = true;
            _inputMap.Player.ShiftModifier.canceled += ctx => ShiftModifier = false;
            _inputMap.Player.Move.performed += ctx => RawInput = ctx.ReadValue<Vector2>().normalized * movementSensitivity * movementSpeedModifier;
            _inputMap.Player.Move.canceled += ctx => RawInput = Vector2.zero;
        }
    }
}