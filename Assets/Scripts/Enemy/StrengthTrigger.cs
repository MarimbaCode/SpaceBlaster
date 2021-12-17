using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class StrengthTrigger : MonoBehaviour
    {
        public float scaleMultiplier = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (other.gameObject.Equals(player))
            {
                PlayerStrengthScale strengthScale = player.GetComponent<PlayerStrengthScale>();

                strengthScale.multiplier = scaleMultiplier;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (other.gameObject.Equals(player))
            {
                PlayerStrengthScale strengthScale = player.GetComponent<PlayerStrengthScale>();

                strengthScale.multiplier = 1;
            }
        }
    }
}
