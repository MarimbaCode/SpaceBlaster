using Player.Firing;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagers.Managers
{
    public class HubLevelManager : LevelManager
    {
        // Start is called before the first frame update
        void Start()
        {
            Init();

            player.GetComponent<PlayerFiring>().enabled = false;



        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public override void GameDeath(string id)
        {
            throw new System.NotImplementedException();
        }

        public override void EventTrigger(string id)
        {
            switch (id)
            {
                case "EnterLevel1":
                    Debug.Log("Change Scene");
                    SceneManager.LoadScene("Scenes/Level1");
                    break;
            }
        }
    }
}
