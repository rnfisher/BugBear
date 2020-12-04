using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerRespawn : MonoBehaviour
    {
        public static PlayerRespawn instance;
        private string currentScene;
        private string playerPrefsScene;
        

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("Scene", currentScene);
        }

        void Update()
        {
            /*if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
                Respawn();
            }*/
        }

        public void Respawn()
        {
            playerPrefsScene = PlayerPrefs.GetString("Scene");
            CanvasManager.instance.LoadSceneByName(playerPrefsScene);
            // Sets Score back to what they had at the beginning of the level
            GameController.instance.SetRespawnScore();
        }
    }
}
