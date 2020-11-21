using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class NextLevel : MonoBehaviour
    {
        public static NextLevel instance;
        private string nextScene;
        public int score;
        public int highScore;
        public Text nextSceneText;
        public Text highScoreText;
        public Text scoreText;
        public GameObject homeBackground;
        public GameObject lvl1Background;
        public GameObject lvl2Background;
        public GameObject lvl3Background;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            nextScene = PlayerPrefs.GetString("NextScene");
            score = PlayerPrefs.GetInt("Score");
            highScore = PlayerPrefs.GetInt("HighScore");
            
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
            //GameController.instance.SetHighScore();
            SetText();
        }

        private void SetText()
        {
            nextSceneText.text = "Next Level: " + nextScene;
            highScoreText.text = "High Score: " + highScore;
            scoreText.text = "Current Score: " + score;
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

