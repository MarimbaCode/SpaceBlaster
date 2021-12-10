using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector2 Rotate(Vector2 vector2, float angle)
    {
        return new Vector2(
            vector2.x * Mathf.Cos(angle) - vector2.y * Mathf.Sin(angle),
            vector2.x * Mathf.Sin(angle) + vector2.y * Mathf.Cos(angle)
        );
    }
}
