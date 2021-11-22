using System;
using UnityEngine;

namespace Enemy
{
    public class Aggro : MonoBehaviour
    {
        public bool persuit;
        
        private GameObject _player;
        private int _aggroTimer;
        public float aggroRange;
        public int aggroTime;

        private ContactFilter2D _filter;

        private void Start()
        {
            _filter = new ContactFilter2D
            {
                useTriggers = false
            };
        }

        // Update is called once per frame
        void FixedUpdate()
        {
    
        
            _player = GameObject.FindWithTag("Player");

            Vector2 position = transform.position;
            Vector2 playerPosition = _player.transform.position;
            Vector2 direction = playerPosition - position;


            RaycastHit2D[] hit = new RaycastHit2D[10];
            GetComponent<CircleCollider2D>().Raycast(direction.normalized, _filter, hit, aggroRange);

            bool foundPlayer = false;

            foreach (RaycastHit2D find in hit)
            {
                if (find.collider == null)
                {
                    break;
                }

                if (find.collider.Equals(_player.GetComponent<CircleCollider2D>()))
                {
                    foundPlayer = true;
                }

                if (find.collider.gameObject.tag.Equals("Border"))
                {
                    break;
                }
            }

            if (foundPlayer)
            {
                _aggroTimer = aggroTime;
                persuit = true;
            }else if (_aggroTimer-- > 0)
            {
                persuit = true;
            }
            else
            {
                persuit = false;
            }

        }
    }
}
