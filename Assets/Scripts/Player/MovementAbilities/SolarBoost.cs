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
            
            /*
            Vector2 mousePosition = ((Vector2) (mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position));
            
            float mouseTheta = Mathf.Atan2(mousePosition.y, mousePosition.x);
            float directionTheta = Mathf.Atan2(direction.y,  direction.x);

            float moveAngle;
            
            if (directionTheta - mouseTheta > 0 && directionTheta - mouseTheta < Mathf.PI)
            {
                moveAngle = Mathf.PI / 2;
            }
            else
            {
                moveAngle = -Mathf.PI / 2;
            }

            Vector2 moveDirection = Utils.Rotate(mousePosition.normalized, moveAngle);
            
            rb.AddForce(moveDirection * 40, ForceMode2D.Impulse);
            */
            
            particleSystem.Play();
            rb.AddForce(direction * 18f, ForceMode2D.Impulse);

        }

    }
}
