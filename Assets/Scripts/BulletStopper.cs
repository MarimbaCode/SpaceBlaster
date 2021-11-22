using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStopper : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Projectile") && other.GetComponent<BoxCollider2D>().Equals(other))
        {
            Destroy(other.gameObject);
        }
    }
}
