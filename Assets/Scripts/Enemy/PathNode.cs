using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PathNode : MonoBehaviour, IComparable<PathNode>
    {

        public List<PathNode> connectedNodes;

        public PathNode nextNode;
        public float dist;

        private GameObject _player;
        private ContactFilter2D _filter;

        private int _depth;
        
        // Start is called before the first frame update
        void Start()
        {
            _filter = new ContactFilter2D
            {
                useTriggers = false
            };
        }

        void FixedUpdate()
        {
            
            _player = GameObject.FindWithTag("Player");

            Vector2 position = transform.position;
            Vector2 playerPosition = _player.transform.position;
            Vector2 direction = playerPosition - position;


            RaycastHit2D[] hit = new RaycastHit2D[10];
            GetComponent<CircleCollider2D>().Raycast(direction.normalized, _filter, hit, 50);

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
                    dist = 9999;
                    break;
                }
            }

            if (foundPlayer)
            {
                dist = Dist(_player.gameObject.transform.position);

                nextNode = null;
                
            }
            else if(nextNode != null)
            {
                dist = nextNode.dist + Dist(nextNode.transform.position);
            }
            UpdateConnections();
        }

        public int GETDepth(List<PathNode> nodes = null)
        {
            if (nodes == null)
            {
                nodes = new List<PathNode>();
            }
            if (nextNode == null)
            {
                return 0;
            }

            if (nodes.Contains(this))
            {
                return 999;
            }
            nodes.Add(this);
            return nextNode.GETDepth(nodes) + 1;
        }
        
            
            
        

        public void UpdateConnections()
        {
            
            foreach(PathNode n in connectedNodes)
            {
                if (n.Equals(nextNode))
                {
                    continue;
                }

                if (n.nextNode == null)
                {
                    n.nextNode = this;

                    n.dist = dist + Dist(n.transform.position);
                } 
                else if (n.nextNode != this)
                {
                    if (n.nextNode.dist > dist + Dist(n.transform.position))
                    {
                        n.nextNode = this;

                        n.dist = dist + Dist(n.transform.position);
                    }
                }
                else
                {
                    n.dist = dist + Dist(n.transform.position);
                }
            }
        }

        public float Dist(Vector3 other)
        {
            return ((Vector2)other - (Vector2)transform.position).magnitude;
        }

        public int CompareTo(PathNode other)
        {
            return GETDepth().CompareTo(other.GETDepth());
        }
    }
}
