using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelManagers.Managers
{
    public class Level1Manager : LevelManager
    {

        public GameObject wall1;
        
        private List<GameObject> _enemies;

        private int _state;
        private int _stateTemp;
        private int _stateActive;

        void Start()
        {
            Init();
            _state = 0;
            _stateTemp = 0;
            UpdateState();
        }
        
        private void FixedUpdate()
        {
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
                case"1":
                    _stateTemp++;
                    break;
                case"boss":
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
