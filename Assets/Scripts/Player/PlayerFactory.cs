using System;
using LevelManagers;
using LevelManagers.Managers;
using Player.Firing;
using UnityEngine;

namespace Player
{
    public class PlayerFactory : MonoBehaviour
    {

        public GameObject playerPrefab;

        public GameObject Create(LevelManager manager)
        {
            GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            
            GetPlayerFiring(newPlayer);

            GetPlayerLife(newPlayer, manager);

            return newPlayer;
        }

        private void GetPlayerFiring(GameObject newPlayer)
        {
            String firingPattern = PlayerPrefs.GetString("PlayerFiringPattern");

            switch (firingPattern)
            {
                case "Single":
                    newPlayer.AddComponent<PlayerFireSingle>();
                    break;
                
                default:
                    newPlayer.AddComponent<PlayerFireSingle>();
                    break;
            }
        }

        private void GetPlayerLife(GameObject newPlayer, LevelManager manager)
        {
            Life life = newPlayer.GetComponent<Life>();

            life.id = "Player";
            life.side = "player";
            life.maxLife = PlayerPrefs.GetInt("PlayerLife");

            if (life.maxLife < 20)
            {
                life.maxLife = 20;
            }





        }
    
    
    
    
    
    
    
    }
}
