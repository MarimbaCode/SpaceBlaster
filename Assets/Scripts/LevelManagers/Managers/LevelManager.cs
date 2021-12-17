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

        public int maxEnergy;
        public int energyRecharge;

        public int gameState = 0;
    
        protected void Init()
        {
            
            Rnd = new System.Random();

            player = playerFactory.Create(this);

            player.GetComponent<Energy>().rechargeRate = energyRecharge;
            player.GetComponent<Energy>().maxEnergy = maxEnergy;
        }

        public abstract void GameDeath(String id);
        public abstract void EventTrigger(String id);

        public void SetRespawnPoint(Vector2 respawnPoint)
        {
            currentRespawn = respawnPoint;
        }

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
            if (player == null)
            {
                player = playerFactory.Create(this);
            }
        }
    }
}
