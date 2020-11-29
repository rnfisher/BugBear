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
        private int lvlScore;

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
            switch (playerPrefsScene)
            {
                case "Level 1":
                    lvlScore = PlayerPrefs.GetInt("Lvl1StartScore");
                    break;
                case "Level 2":
                    lvlScore = PlayerPrefs.GetInt("Lvl2StartScore");
                    break;
                case "Level 3":
                    lvlScore = PlayerPrefs.GetInt("Lvl3StartScore");
                    break;
                case "Level 4 Endless":
                    lvlScore = PlayerPrefs.GetInt("Lvl4StartScore");
                    break;
                default:
                    break;
            }
            GameController.instance.SetRespawnScore(lvlScore);
        }
    }
}
