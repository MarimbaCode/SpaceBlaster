using System;
using UnityEngine;

namespace Player.Firing
{
    public class NebulaBoltMovement : MonoBehaviour
    {
        public Vector2 direction;
        public Rigidbody2D rb;
        public CircleCollider2D bulletCollider;
        public String side;

        public int damage;
        public int pierce;

        private const int Life = 100;
        private int _life;
    
        void Start()
        {
            _life = Life;
            rb.velocity = direction * 4;
            float angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);
        }

        void FixedUpdate()
        {
            if (_life-- <= 0 || pierce <= 0)
            {
                Destroy(gameObject);
            }

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
            transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);
        }

        private void OnCollisionEnter2D(Collision2D other)
        { 
            if (other.gameObject.GetComponent<Life>() != null)
            {
                String otherSide = other.gameObject.GetComponent<Life>().side;
                if (!otherSide.Equals(side))
                {
                    other.gameObject.GetComponent<Life>().Damage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
