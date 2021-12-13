using UnityEngine;
using UnityEngine.U2D;

namespace CameraMovements
{
    public class CameraMovement : MonoBehaviour
    {
        public PixelPerfectCamera pixelPerfectCamera;
        public Vector2 llBounds, urBounds;
        public float scale;
        
        
        void Update()
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (GameObject.FindWithTag("Player") != null)
            {
                Vector2 goalPosition = player.transform.position;
                var position = transform.position;

                float scalex = scale * 16f / 9f;
                if (llBounds.x + scalex <= urBounds.x - scalex)
                {
                    if (goalPosition.x - scalex < llBounds.x)
                    {
                        goalPosition.x = llBounds.x + scalex;
                    }

                    if (goalPosition.x + scalex > urBounds.x)
                    {
                        goalPosition.x = urBounds.x - scalex;
                    }
                }
                else
                {
                    goalPosition.x = (llBounds.x + urBounds.x) / 2;
                }

                if (llBounds.y + scale <= urBounds.y - scale)
                {
                    if (goalPosition.y + scale > urBounds.y)
                    {
                        goalPosition.y = urBounds.y - scale;
                    }

                    if (goalPosition.y - scale < llBounds.y)
                    {
                        goalPosition.y = llBounds.y + scale;
                    }
                }
                else
                {
                    goalPosition.y = (llBounds.y + urBounds.y) / 2;
                }

                Vector2 deltaPos = (goalPosition - (Vector2) position) * Time.deltaTime * 4;

                if (deltaPos.magnitude > 8)
                {
                    deltaPos = deltaPos.normalized * 8;
                }
                position += (Vector3) deltaPos;

                
                transform.position = position;

                Camera currentCamera = GetComponent<Camera>();
                float newSize = currentCamera.orthographicSize + (scale - currentCamera.orthographicSize) * Time.deltaTime * 8;
                currentCamera.orthographicSize = newSize;

            }
        }
    }
}
