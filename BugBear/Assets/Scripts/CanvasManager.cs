using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Player
{
    public class CanvasManager : MonoBehaviour
    {
        public static CanvasManager instance;
        public GameObject pauseMenu;
        public GameObject deathMenu;
        public GameObject optionsMenu;
        public GameObject homeOptionsMenu;
        public GameObject homeMenu;
        public GameObject bugBearHealth;
        public GameObject joystick;
        public GameObject fire;
        private string currentScene;
        //public Button pauseBtn;
        //public Button fireBtn;
        [HideInInspector] public static string nextScene;
        [HideInInspector] public bool gameIsPaused;
        public Toggle toggle;
        private string leftHandedPref;
        private bool isLeftHanded;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            gameIsPaused = false;
            print(currentScene);

            StartCheckLeftHanded();
            toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(toggle);
            });
         
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                //BottomRight(fire);
                //BottomLeft(joystick);
                //print("space key was pressed");
                //PlayerPrefs.SetString("LeftHanded", "");
            }
        }

        private void StartCheckLeftHanded()
        {
            leftHandedPref = PlayerPrefs.GetString("LeftHanded");
            print(leftHandedPref);
            if (leftHandedPref == "")
            {
                PlayerPrefs.SetString("LeftHanded", "false");
                toggle.isOn = false;
                isLeftHanded = false;
            }
            SwitchControls(leftHandedPref);
        }

        private void ToggleValueChanged(Toggle change)
        {
            isLeftHanded = toggle.isOn;
            leftHandedPref = isLeftHanded.ToString();
            PlayerPrefs.SetString("LeftHanded", leftHandedPref);
            SwitchControls(leftHandedPref);
        }

        private void SwitchControls(string hand)
        {
            switch (hand)
            {
                case "True":
                    toggle.isOn = true;
                    isLeftHanded = true;
                    BottomRight(fire);
                    BottomLeft(joystick);
                    break;
                case "False":
                    toggle.isOn = false;
                    isLeftHanded = false;
                    BottomRight(joystick);
                    BottomLeft(fire);
                    break;
                default:
                    break;
            }
        }

        private void BottomRight(GameObject uiObject)
        {
            RectTransform uitransform = uiObject.GetComponent<RectTransform>();

            uitransform.anchorMin = new Vector2(1, 0);
            uitransform.anchorMax = new Vector2(1, 0);
            uitransform.pivot = new Vector2(1, 0);
        }

        private void BottomLeft(GameObject uiObject)
        {
            RectTransform uitransform = uiObject.GetComponent<RectTransform>();

            uitransform.anchorMin = new Vector2(0, 0);
            uitransform.anchorMax = new Vector2(0, 0);
            uitransform.pivot = new Vector2(0, 0);
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
            //print("gameIsPaused" + gameIsPaused);
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
            Pause();
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
            if (sceneName == "Home" || sceneName == "LvlSelect")
            {
                PlayerPrefs.SetInt("Score", 0);
            }
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
            SceneSettings(sceneName);
        }

        private void SceneSettings(string s)
        {
            switch (s)
            {
                case "Home":
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case "Level Select":
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case "Level 1":

                    break;
                case "Level 2":

                    break;
                default:
                    break;
            }
        }
    }
}

