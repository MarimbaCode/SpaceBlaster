using UnityEngine;

namespace CameraMovements
{
    public class BackgroundMovement : MonoBehaviour
    {
        private Transform _cameraTransform;

        public Vector2 startOffset;
// Update is called once per frame
        void Update()
        {

            _cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
            
            Vector3 newPos = (Vector3) startOffset + _cameraTransform.position * -0.2f + _cameraTransform.position;

            newPos.z = 100;

            transform.position = newPos;
        }
    }
}
