using System;
using UnityEngine;

namespace Player.MovementAbilities
{
    public class SolarBoost : Movement
    {

        public ParticleSystem particleSystem;
        private void Start()
        {
            energyCost = 10;
            cooldownTime = 40;
        }

        public override void Move()
        {

            bool w = Input.GetKey(KeyCode.W);
            bool a = Input.GetKey(KeyCode.A);
            bool s = Input.GetKey(KeyCode.S);
            bool d = Input.GetKey(KeyCode.D);

            Vector2 direction = new Vector2();

            if (w)
            {
                direction += Vector2.up;
            }
            if (a)
            {
                direction += Vector2.left;
            }
            if (s)
            {
                direction += Vector2.down;
            }
            if (d)
            {
                direction += Vector2.right;
            }

            if (direction.Equals(Vector2.zero))
            {
                direction = Vector2.right;
            }

            direction.Normalize();
            
            particleSystem.Play();
            rb.AddForce(direction * 18f, ForceMode2D.Impulse);
            
            life.AddInvincibility(50);
        }

    }
}
