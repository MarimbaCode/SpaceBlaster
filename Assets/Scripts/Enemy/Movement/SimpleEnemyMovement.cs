using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class SimpleEnemyMovement : EnemyMovement
    {



        public override void SeenMovement()
        {
            if (player != null)
            {
                goalPosition = player.transform.position;
            }
        }
    }
}
