using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class SimpleEnemyMovement : MonoBehaviour
    {

        private GameObject _player;
        public Rigidbody2D rb;
        public CircleCollider2D enemyCollider;


        private const int Speed = 10;

        private int _orbitDirection;


        public PathNode aim;
        public int pos;


        private ContactFilter2D _filter;

        // Start is called before the first frame update
        void Start()
        {

            _orbitDirection = new Random().NextDouble() > 0.5 ? -1 : 1;

            _filter = new ContactFilter2D
            {
                useTriggers = true,

            };

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _player = GameObject.FindWithTag("Player");

            Vector2 position = transform.position;
            Vector2 playerPosition = _player.transform.position;

            bool foundPlayer = FindPlayer();

            if (GetComponent<Aggro>().persuit)
            {
                if (foundPlayer)
                {
                    Move(playerPosition);
                    aim = null;
                }
                else
                {
                    // PathFind();

                    Vector2 goal = PathFind();

                    Move(goal);

                }
            }
        }

        bool FindPlayer()
        {
            Vector2 position = transform.position;
            Vector2 playerPosition = _player.transform.position;
            Vector2 direction = playerPosition - position;
            RaycastHit2D[] hit = new RaycastHit2D[10];
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

        void Move(Vector2 goal)
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

        private Vector2 PathFind()
        {

            GameObject[] nodes = GameObject.FindGameObjectsWithTag("Pathfinding");

            Debug.Log(nodes.Length);

            PathNode closest = null;

            foreach (GameObject node in nodes)
            {
                Vector2 direction = (node.transform.position - transform.position);

                RaycastHit2D[] hits = new RaycastHit2D[100];
                GetComponent<CircleCollider2D>().Raycast(direction, hits, 100f);

                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject.tag.Equals("Border"))
                    {
                        break;
                    }

                    if (hit.collider.gameObject.tag.Equals("Pathfinding"))
                    {
                        PathNode foundNode = hit.collider.gameObject.GetComponent<PathNode>();
                        if (closest == null)
                        {
                            closest = foundNode;
                        }
                        else
                        {
                            if (closest.GETDepth() > foundNode.GETDepth())
                            {
                                closest = foundNode;
                            }
                        }
                    }
                }


            }

            if (closest != null)
            {
                return closest.transform.position;
            }
            else
            {
                return transform.position;
            }
        }

    }
}
