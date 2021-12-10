using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {

        public Rigidbody2D rb;
        public Collider2D enemyCollider;
        public GameObject player;
        public Seeker seeker;
        public Aggro aggro;

        public int speed;

        public Vector2 goalPosition;
        public Vector2 startPos;

        public Vector2 playerDirection;


        public bool useAStar = true;
        public int currentWaypoint;
        public float nextWaypointDistance = 0.5f;
        public bool reachedEndOfPath;
        public Path currentPath;

        public int pathCooldownTime = 40;
        public int pathCooldown = 0;

        public ContactFilter2D filter;
        private void Start()
        {
            startPos = transform.position;
            player = GameObject.FindWithTag("Player");
            filter = new ContactFilter2D()
            {
                useTriggers = false
            };
        }

        private void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player"); 
            }


            if (player != null)
            {
                playerDirection = ((Vector2)(player.transform.position - transform.position)).normalized;
            }
        }

        private void FixedUpdate()
        {
            if (pathCooldown-- < 0)
            {
                seeker.StartPath(transform.position, player.transform.position, PathComplete);
                pathCooldown = pathCooldownTime;
            }


            if (aggro.persuit)
            {
                if (PlayerVisible())
                {
                    SeenMovement();
                }
                else
                {
                    PathMovement();
                }
            }
            else
            {
                goalPosition = startPos;
            }
            Move();
        }

        public void PathComplete(Path p)
        {
            Debug.Log("Path found? " + p.errorLog);
            if (!p.error)
            {
                currentPath = p;
                currentWaypoint = 0;
            }
        }

        public abstract void SeenMovement();

        public void PathMovement()
        {
            if (currentPath == null) {
                return;
            }

            reachedEndOfPath = false;
            float distanceToWaypoint;
            while (true) {
                distanceToWaypoint = Vector3.Distance(transform.position, currentPath.vectorPath[currentWaypoint]);
                if (distanceToWaypoint < nextWaypointDistance) {

                    if (currentWaypoint + 1 < currentPath.vectorPath.Count) {
                        currentWaypoint++;
                    } else {
                        reachedEndOfPath = true;
                        break;
                    }
                } else {
                    break;
                }
            }

            goalPosition = currentPath.vectorPath[currentWaypoint];

        }
        public bool PlayerVisible()
        {

            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            enemyCollider.Raycast(playerDirection, filter, hits);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.tag.Equals("Border"))
                {
                    break;
                }
                if (hit.collider.gameObject.Equals(player))
                {
                    return true;
                }
            }

            return false;
        }

        public void Move()
        {
            rb.AddForce((goalPosition - (Vector2) transform.position).normalized * speed);
        }
    }
}
