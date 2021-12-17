using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class SimpleEnemyMovement : EnemyMovement
    {
        public int followDist = 2;
        public override void SeenMovement()
        {
            if (player != null)
            {
                if ((player.transform.position - transform.position).magnitude < followDist)
                {
                    goalPosition = (Vector2)transform.position + (Vector2)(player.transform.position - transform.position).normalized * 2;
                }
                else
                {
                    goalPosition = player.transform.position;
                }
            }
        }
    }
}
