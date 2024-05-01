using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Camera
{
    public class CameraManager: MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5f; // Speed of movement
        public float minX = -5f; // Minimum X position
        public float maxX = 5f; // Maximum X position
        public float minZ = -5f; // Minimum Z position
        public float maxZ = 5f; // Maximum Z position

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            
            Vector3 movementAmount = movementDirection * _movementSpeed * Time.deltaTime;
            
            transform.Translate(movementAmount);
            
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
            transform.position = clampedPosition;
        }
    }
}