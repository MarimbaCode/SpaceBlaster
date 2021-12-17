using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelManagers.Managers
{
    public class Level1Manager : LevelManager
    {

        public GameObject door1;
        public GameObject door2;

        
        private List<GameObject> _enemies;

        private int _state;
        private int _stateTemp;
        private int _stateActive;

        private int enemyADeaths;

        void Start()
        {
            Init();
            _state = 0;
            _stateTemp = 0;
            lives = 5;
            
            UpdateState();
        }
        
        private void FixedUpdate()
        {

            if (enemyADeaths >= 4)
            {
                Destroy(door1);
            }
            
            
            switch (_state)
            {
                
            }
        }

        public void UpdateState()
        {
            switch (_state)
            {
                
            }
        }


        public override void GameDeath(String id)
        {
            switch (id)
            {
                case"A":
                    enemyADeaths++;
                    break;
                case"SEC-1":
                    Destroy(door2);
                    break;
            }
        }

        public override void EventTrigger(string id)
        {
            switch (id)
            {

            }
        }
    }
}
