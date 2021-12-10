using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagers.Managers
{
    public abstract class LevelManager : MonoBehaviour
    {

        public PlayerFactory playerFactory;
        
        public EnemySpawner spawner;
        public GameObject player;

        public Vector2 currentRespawn;
        public int lives;
        
        protected System.Random Rnd;

        public int gameState = 0;
    
        protected void Init()
        {
            
            Rnd = new System.Random();

            player = playerFactory.Create(this);
        }

        public abstract void GameDeath(String id);
        public abstract void EventTrigger(String id);

        public void RespawnPlayer()
        {
            if (lives > 0)
            {
                StartCoroutine(SpawnPlayerDelayed());
            }
            else
            {
                SceneManager.LoadScene("Hub");
            }
        }

        public IEnumerator SpawnPlayerDelayed()
        {
            yield return new WaitForSeconds(3);
            player = playerFactory.Create(this);

        }
    }
}
