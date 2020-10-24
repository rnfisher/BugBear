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
        public GameObject optionsMenu;
        public GameObject healthBar;
        public Slider slider;
        public GameObject joystick;
        public Button pauseBtn;
        public Button fireBtn;
        public Text ScoreText;
        //private float timerValue;
        [HideInInspector] private string currentScene;
        [HideInInspector] public static string nextScene;
        [HideInInspector] public bool GameIsPaused;
        private int score;
        private float counterTimer;
        public float updateAmountHealth = 1; //Amount that the health declines
        public float counterTimerMax = 0.2f;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            GameIsPaused = false;
            //UnlockScreen();
            //Screen.SetResolution(1920, 1080, true);
            currentScene = SceneManager.GetActiveScene().name;
            score = 0;
            UpdateScore();
            //DrainHealth();
        }

        void Update()
        {
            /*if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }*/
        }

        private void FixedUpdate()
        {
            //if (hurting && !inCinematic)
            //if (hurting && !inCinematic)
            //{
                counterTimer -= Time.fixedDeltaTime;
                if (counterTimer <= 0)
                {
                    //TakeDamage(updateAmountHealth, false);
                    counterTimer = counterTimerMax;

                }

            //}
        }

        private void LateStart()
        {
            counterTimer = counterTimerMax;
        }

        public void LockScreen()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

        }

        public void UnlockScreen()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            LockScreen();
        }

        public void Resume()
        {
            GameIsPaused = false;
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

        /*void DrainHealth()
        {
            timerValue -= Time.deltaTime;
            if (timerValue <= 0 && slider.value != 0)
            {
                slider.value = -healthDepleteSpeed;
                //Debug.Log(slider.value);
            }
        }*/

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }
}

