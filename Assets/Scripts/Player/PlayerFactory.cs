using System;
using LevelManagers;
using LevelManagers.Managers;
using Player.Firing;
using UnityEngine;

namespace Player
{
    public class PlayerFactory : MonoBehaviour
    {
        public bool overrideAttack;
        public String newAttack;

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

            if (overrideAttack)
            {
                firingPattern = newAttack;
            }

            switch (firingPattern)
            {
                case "SolarSingle":
                    newPlayer.AddComponent<PlayerFireSolarBolt>();
                    break;
                case "NebulaSingle":
                    newPlayer.AddComponent<PlayerFireNebulaBolt>();
                    break;
                case "VortexSingle":
                    newPlayer.AddComponent<PlayerFireVortexBolt>();
                    break;
                default:
                    newPlayer.AddComponent<PlayerFireSolarBolt>();
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
