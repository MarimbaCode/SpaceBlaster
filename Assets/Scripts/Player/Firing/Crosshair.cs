using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            position.z = 3;
            transform.position = position;

        }
        
    }
}
