using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class CanvasManager : MonoBehaviour
    {
        public static CanvasManager instance;
        public GameObject pauseMenu;
        public GameObject deathMenu;
        public GameObject optionsMenu;
        public GameObject bugBearHealth;
        
        public GameObject joystick;
        public Button pauseBtn;
        public Button fireBtn;
        public Text ScoreText;
        [HideInInspector] public static string nextScene;
        [HideInInspector] public bool gameIsPaused;
        private int score;
        

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            gameIsPaused = false;
            score = 0;
            UpdateScore();
        }

        void Update()
        {
            /*if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }*/
        }

        public void LockScreen()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PlayerHealth.instance.TakeDamageToggle();
        }

        public void UnlockScreen()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            Time.timeScale = 1f;
            PlayerHealth.instance.TakeDamageToggle();
        }

        public void Pause()
        {
            if (gameIsPaused)
            {
                gameIsPaused = false;
                pauseMenu.SetActive(false);
                UnlockScreen();
            }
            else
            {
                gameIsPaused = true;
                pauseMenu.SetActive(true);
                LockScreen();
            }
        }

        public void Death()
        {
            deathMenu.SetActive(true);
            Pause();
        }

        public void ReplayLevel()
        {
            PlayerRespawn.instance.Respawn();
        }

        public void Resume()
        {
            gameIsPaused = false;
            pauseMenu.SetActive(false);
            UnlockScreen();
        }

        public void Fire()
        {
            PlayerController.instance.FireWeapon();
        }

        public void OptionsMenu()
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void Back()
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }

        // Load Scenes by name
        public void LoadSceneByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
            SceneSettings(sceneName);
        }

        public void SceneSettings(string s)
        {
            switch (s)
            {
                case "Home":
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case "Level 1":

                    break;
                default:
                    break;
            }
        }
        public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            UpdateScore();
        }
        void UpdateScore()
        {
            ScoreText.text = "Score: " + score;
        }
    }
}

