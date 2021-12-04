using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class SimpleEnemyMovement : MonoBehaviour
    {

        private GameObject _player;
        public Rigidbody2D rb;
        
        public Vector2 goal;
        private Vector2 _playerSeenPosition;
        private Vector2 _startPosition;
        
        private const int Speed = 10;

        private int _orbitDirection;

        

        private ContactFilter2D _filter;

        // Start is called before the first frame update
        void Start()
        {

            _orbitDirection = new Random().NextDouble() > 0.5 ? -1 : 1;

            _filter = new ContactFilter2D
            {
                useTriggers = true,
            };

            _startPosition = transform.position;

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _player = GameObject.FindWithTag("Player");
            Movement();
        }


        public void Movement()
        {
            Vector2 playerPosition = _player.transform.position;

            bool foundPlayer = FindPlayer();

            if (GetComponent<Aggro>().persuit)
            {
                if (foundPlayer)
                {
                    _playerSeenPosition = playerPosition;
                }

                goal = _playerSeenPosition;
            }

            if (GetComponent<Aggro>().persuit)
            {
                Move();
            }
            
        }

        bool FindPlayer()
        {
            Vector2 position = transform.position;
            Vector2 playerPosition = _player.transform.position;
            Vector2 direction = playerPosition - position;
            RaycastHit2D[] hit = new RaycastHit2D[4];
            GetComponent<CircleCollider2D>().Raycast(direction.normalized, _filter, hit, 100);

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

            return foundPlayer;
        }

        void Move()
        {
            Vector2 direction = goal - (Vector2) transform.position;

            if (direction.magnitude > 2)
            {
                rb.AddForce(direction.normalized * Speed);
            }
            else if (direction.magnitude < 1)
            {
                rb.AddForce(direction.normalized * -Speed);
            }
            else
            {
                float newX = direction.x * Mathf.Cos(Mathf.PI / 2 * _orbitDirection) -
                             direction.y * Mathf.Sin(Mathf.PI / 2f * _orbitDirection);
                float newY = direction.x * Mathf.Sin(Mathf.PI / 2 * _orbitDirection) +
                             direction.y * Mathf.Cos(Mathf.PI / 2f * _orbitDirection);
                rb.AddForce(new Vector2(newX, newY) * Speed / 8f);
            }
        }

        

    }
}
