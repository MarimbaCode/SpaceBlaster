using UnityEngine;

namespace LevelManagers.Managers
{
    public class SampleLevelManager : LevelManager
    {
        
        
        void FixedUpdate()
        {
            if (Rnd.NextDouble() > 0.99)
            {
                GameObject enemy = spawner.CreateNormalEnemy("1",new Vector2((float)Rnd.NextDouble() * 20 - 10, (float)Rnd.NextDouble() * 20 - 10));
            }
            
            
        }

        public override void GameDeath(string id)
        {
            throw new System.NotImplementedException();
        }

        public override void EventTrigger(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
