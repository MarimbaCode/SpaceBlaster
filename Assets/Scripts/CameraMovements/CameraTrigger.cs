using UnityEngine;

namespace CameraMovements
{
    public class CameraTrigger : MonoBehaviour
    {
        private GameObject _mainCamera;

        public Vector2 lowerLeftBounds, upperRightBounds;
        public float scale = 5;

        private void Start()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera");
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if ( other.Equals(GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>()))
        //     {
        //         CameraMovement movement = _mainCamera.GetComponent<CameraMovement>();
        //         movement.llBounds = lowerLeftBounds;
        //         movement.urBounds = upperRightBounds;
        //         movement.scale = scale;
        //     }
        // }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.Equals(GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>()))
            {
                Debug.Log("CAMERA MOVE");
                CameraMovement movement = _mainCamera.GetComponent<CameraMovement>();
                movement.llBounds = lowerLeftBounds;
                movement.urBounds = upperRightBounds;
                movement.scale = scale;
            }
        }
    }
}
