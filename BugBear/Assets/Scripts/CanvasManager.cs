using System.Collections;
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
        public GameObject joystick;
        public Button pauseBtn;
        public Button fireBtn;
        [HideInInspector] private string currentScene;
        [HideInInspector] public static string nextScene;
        [HideInInspector] public bool GameIsPaused;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            GameIsPaused = false;
            //UnlockScreen();
            Screen.SetResolution(1920, 1080, true);
            currentScene = SceneManager.GetActiveScene().name;
            pauseBtn.SetActive(false);
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
    }
}

