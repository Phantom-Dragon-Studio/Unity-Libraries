using UnityEngine;

namespace PhantomDragonStudio.Input
{
    [System.Serializable]
    public class RotationProcessor
    {
        [Range(0f, 5f)] [SerializeField] private float rotationSensitivity = 1f;
        [Range(0f, 5f)] [SerializeField] private float rotationSpeed = 1f;

        private InputMap _inputMap;
        private bool isRotating;

        public void Initialize()
        {
            _inputMap = InputSystem_Manager.Map;
            _inputMap.Player.RotateCamera.Enable();
            _inputMap.Player.RotateCamera.performed += ctx => isRotating = true;
            _inputMap.Player.RotateCamera.canceled += ctx => isRotating = false;
        }

        public void Rotate(GameObject objectToRotate, GameObject cam, Vector2 rotationalVector)
        {
            if (!isRotating) return;
            objectToRotate.transform.Rotate(Vector3.up, CalculateRotation(rotationalVector.x));
            objectToRotate.transform.Rotate(Vector3.left, CalculateRotation(rotationalVector.y));
            
            //Fine Tuning the camera & parent alignment.
            cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, objectToRotate.transform.eulerAngles.y, cam.transform.localEulerAngles.z);
        }

        public float CalculateRotation(float rotation)
        {
            return rotation 
                   * Mathf.PI 
                   * rotationSensitivity 
                   * rotationSpeed 
                   * Time.smoothDeltaTime;
        }
        
        public float CalculateRotationRounded(float rotation)
        {
            return Mathf.Round(rotation
                               * Mathf.PI
                               * rotationSensitivity
                               * rotationSpeed
                               * Time.smoothDeltaTime);
        }
    }
}