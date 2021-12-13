using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletMovement : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    public CircleCollider2D bulletCollider;
    public String side;

    public int damage;
    public int pierce = 1;

    public int life;


    void Start()
    {
        rb.velocity = direction * 4;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);
    }

    void FixedUpdate()
    {
        if (life-- <= 0 || pierce <= 0)
        {
            Destroy(gameObject);
        }

        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Border"))
        {
            Destroy(gameObject);
        }else if (other.gameObject.GetComponent<Life>() != null)
        {
            String otherSide = other.gameObject.GetComponent<Life>().side;
            if (!otherSide.Equals(side))
            {
                if (--pierce <= 0)
                {
                    other.gameObject.GetComponent<Life>().Damage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
