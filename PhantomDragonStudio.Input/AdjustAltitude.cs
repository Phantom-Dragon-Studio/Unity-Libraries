using UnityEngine;

namespace PhantomDragonStudio.Input
{
    public class AdjustAltitude
    {
        private float minDistance, maxDistance;
        private Vector3 objVelocity = Vector3.zero;
        private Vector2 _getHeight;

        public AdjustAltitude(float min, float max)
        {
            minDistance = min;
            maxDistance = max;
            InputSystem_Manager.Map.Player.Altitude.Enable();
            InputSystem_Manager.Map.Player.Altitude.performed += ctx => _getHeight = ctx.ReadValue<Vector2>();;
            InputSystem_Manager.Map.Player.Altitude.canceled += ctx => _getHeight = Vector2.zero;;
        }

        public void Altitude(Transform transform)
        {
            var localPosition = transform.localPosition;

            var heightVector = new Vector3(localPosition.x,
                Mathf.Clamp(localPosition.y + _getHeight.y, minDistance, maxDistance),
                localPosition.z);

            transform.localPosition = Vector3.SmoothDamp(localPosition,
                heightVector, ref objVelocity,
                Time.smoothDeltaTime
            );
        }
    }
}