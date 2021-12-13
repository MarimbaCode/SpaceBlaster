using UnityEngine;

namespace CameraMovements
{
    public class CameraTrigger : MonoBehaviour
    {
        private GameObject _mainCamera;

        public Transform lowerLeftBounds, upperRightBounds;
        public float scale = 5;

        private void Start()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.Equals(GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>()))
            {
                Debug.Log("CAMERA MOVE");
                CameraMovement movement = _mainCamera.GetComponent<CameraMovement>();
                movement.llBounds = lowerLeftBounds.position;
                movement.urBounds = upperRightBounds.position;
                movement.scale = scale;
            }
        }
    }
}
