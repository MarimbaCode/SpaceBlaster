using System;
using Player;
using UnityEngine;

namespace LevelManagers.Managers
{
    public abstract class LevelManager : MonoBehaviour
    {

        public PlayerFactory playerFactory;
        
        public EnemySpawner spawner;
        public GameObject player;

        protected System.Random Rnd;

        public int gameState = 0;
    
        protected void Init()
        {
            
            Rnd = new System.Random();

            player = playerFactory.Create(this);
        }

        public abstract void GameDeath(String id);
        public abstract void EventTrigger(String id);

    }
}
