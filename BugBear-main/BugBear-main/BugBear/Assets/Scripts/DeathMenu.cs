using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class DeathMenu : MonoBehaviour
    {
        public int score;
        public int highScore;
        public Text highScoreText;
        public Text scoreText;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            score = GameController.instance.score;
            //highScore = GameController.instance.highScore;
            //score = PlayerPrefs.GetInt("Score");
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore;
            scoreText.text = "Current Score: " + score;
        }

        public void OnEnable()
        {

        }
    }
}
