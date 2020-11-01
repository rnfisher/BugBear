using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class NextLevel : MonoBehaviour
    {
        private string nextScene;
        public Text nextSceneText;
        public GameObject homeBackground;
        public GameObject lvl1Background;
        public GameObject lvl2Background;
        public GameObject lvl3Background;

        void Start()
        {
            nextScene = PlayerPrefs.GetString("NextScene");
            SetNextLevelText();
            switch (nextScene)
            {
                case "Home":
                    homeBackground.SetActive(true);
                    break;
                case "Level 1":
                    lvl1Background.SetActive(true);
                    break;
                case "Level 2":
                    lvl2Background.SetActive(true);
                    break;
                case "Level 3":
                    lvl3Background.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        private void SetNextLevelText()
        {
            nextSceneText.text = "Next Level: " + nextScene;
        }

        public void GoToNextLevel()
        {
            if (nextScene == "Home")
            {
                GameController.instance.ScoreTextAvailable();
                GameController.instance.ClearScore();
            }
            CanvasManager.instance.LoadSceneByName(nextScene);
        }
    }
}

