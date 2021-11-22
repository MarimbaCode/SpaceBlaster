using System;
using LevelManagers.Managers;
using UnityEngine;

namespace LevelManagers
{
    public class EventTrigger : MonoBehaviour
    {

        public GameObject manager;
        public String id;

        public int sustainTime;
        private int _sustain;
        

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _sustain++;
                if(_sustain >= sustainTime){
                    manager.GetComponent<LevelManager>().EventTrigger(id); 
                }
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _sustain = 0;
            }
            
        }
    }
}
