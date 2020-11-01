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

        void Start()
        {
            nextScene = PlayerPrefs.GetString("NextScene");
            SetNextLevelText();
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

