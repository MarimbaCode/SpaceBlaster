using System;
using LevelManagers.Managers;
using UnityEngine;

namespace LevelManagers
{
    public class EnemySpawner : MonoBehaviour
    {
        public static String enemyPath = "Prefabs/enemies/";

        public static GameObject NormalEnemy;

        public LevelManager manager;

        private void Start()
        {
            NormalEnemy = Resources.Load(enemyPath + "NormalEnemy") as GameObject;
        }


        public GameObject CreateNormalEnemy(String id, Vector2 position = new Vector2())
        {
            GameObject enemy = Instantiate(NormalEnemy, position, Quaternion.identity);
            enemy.GetComponent<Life>().id = id;
            enemy.GetComponent<Life>().manager = manager;



            return enemy;
        }
        
        
        




    }
}
