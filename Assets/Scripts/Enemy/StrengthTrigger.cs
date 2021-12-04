using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class StrengthTrigger : MonoBehaviour
    {
        public float scaleMultiplier = 1;

        private void OnTriggerStay(Collider other)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (other.gameObject.Equals(player))
            {
                PlayerStrengthScale strengthScale = player.GetComponent<PlayerStrengthScale>();

                strengthScale.multiplier = scaleMultiplier;
            }
        }
    }
}
