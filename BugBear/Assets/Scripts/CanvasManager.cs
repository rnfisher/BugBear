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
        [HideInInspector] public static string nextScene;
        [HideInInspector] public bool gameIsPaused;
        public Toggle toggle;
        private string leftHandedPref;
        private bool isLeftHanded;

        public Animator bearAnimator;
        public GameObject bearSkin;
        public GameObject bearSkin2;
        public GameObject bearSkin3;

        private Button pauseBtn;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            gameIsPaused = false;
            pauseBtn = GameObject.Find("PauseBTN").GetComponent<Button>();

            if (currentScene != "LvlSelect")
            {
                StartCheckLeftHanded();
                toggle.onValueChanged.AddListener(delegate {
                    ToggleValueChanged(toggle);
                });
            }

        }

        void Update()
        {
            /*if (Input.GetKeyDown("space"))
            {

            }*/
        }

        private void StartCheckLeftHanded()
        {
            leftHandedPref = PlayerPrefs.GetString("LeftHanded");
            //print(leftHandedPref);
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

        void OnApplicationFocus()
        {
            //isPaused = !hasFocus;
            //Debug.Log(hasFocus);
            Pause();
        }

        void OnApplicationPause()
        {
            //isPaused = pauseStatus;
            //Debug.Log(pauseStatus);
            Pause();
        }

        public void Death()
        {
            StartCoroutine(BearDeath());
        }

        public void ReplayLevel()
        {
            PlayerRespawn.instance.Respawn();
            GameController.instance.ClearScore();
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
            pauseBtn.interactable = false;
        }

        public void Back()
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            pauseBtn.interactable = true;
        }

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

        IEnumerator BearDeath()
        {
            bearSkin = GameObject.Find("Sprite_Original");// Get Original Sprite
            bearSkin2 = GameObject.Find("Sprite_TopHat");// Get TopHat Sprite
            bearSkin3 = GameObject.Find("Sprite_Swim");// Get Swim Sprite

            if (bearSkin != null)
            {
                bearAnimator = bearSkin.GetComponent<Animator>();
            }
            if (bearSkin2 != null)
            {
                bearAnimator = bearSkin2.GetComponent<Animator>();
            }
            if (bearSkin3 != null)
            {
                bearAnimator = bearSkin3.GetComponent<Animator>();
            }

            bearAnimator.SetInteger("AnimState", 1); // go into death animation
            yield return new WaitForSeconds(.5f); // time of animation
            deathMenu.SetActive(true);
            Pause();
        }
    }
}

