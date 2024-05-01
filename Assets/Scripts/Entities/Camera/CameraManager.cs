using UnityEngine;

namespace Entities.Camera
{ 
    public interface ICameraMovement
    {
        void MoveCamera(Vector3 direction);
    }

    public class CameraManager : MonoBehaviour, ICameraMovement
    {
        [SerializeField] private float _movementSpeed = 5f; // Speed of movement
        [SerializeField] private Vector2 _xLimitation; // min/ max x movement pos
        [SerializeField] private Vector2 _zLimitation;// min/ max y movement pos

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            MoveCamera(movementDirection);
        }

        public void MoveCamera(Vector3 direction)
        {
            Vector3 movementAmount = direction * _movementSpeed * Time.deltaTime;
            transform.Translate(movementAmount);
            ClampCameraPosition();
        }

        private void ClampCameraPosition()
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, _xLimitation.x, _xLimitation.y);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, _zLimitation.x, _zLimitation.y);
            transform.position = clampedPosition;
        }
    }
}