using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerStrengthScale : MonoBehaviour
    {


        public float additive;
        public float multiplier;

        private int _cooldown = 0;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_cooldown-- <= 0)
            {

                additive = 1;
                multiplier = 0;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject enemy in enemies)
                {
                    if (((Vector2) enemy.transform.position - (Vector2) transform.position).magnitude < 20)
                    {
                        StrengthScale scale = enemy.GetComponent<StrengthScale>();
                        additive += scale.scaleFactor/50f;
                        multiplier *= scale.scaleMultiplier;
                    }
                }

                _cooldown = 10;
            }
        }
    }
}
