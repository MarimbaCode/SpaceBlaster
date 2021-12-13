using UnityEngine;

namespace Player.Firing
{
    public class Crosshair : MonoBehaviour
    {

        private void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        
            Camera camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

            if (camera != null)
            {
                Vector3 position = camera.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                transform.position = position;

            }
        }
    }
}
