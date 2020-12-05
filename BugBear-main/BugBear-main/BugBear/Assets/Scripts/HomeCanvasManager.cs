using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;


public class HomeCanvasManager : MonoBehaviour
{
    public GameObject homeOptionsMenu;
    public GameObject homeMenu;
    private string currentScene;
    public Toggle toggle;
    private string leftHandedPref;
    private bool isLeftHanded;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        print(currentScene);

        //Add listener for when the state of the Toggle changes, to take action
        if (currentScene != "LvlSelect" || currentScene != "Customize" || currentScene != "LvlTransition")
        {
            StartCheckLeftHanded();
            toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(toggle);
            });
                
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
                break;
            case "False":
                toggle.isOn = false;
                isLeftHanded = false;
                break;
            default:
                break;
        }
    }

    public void HomeOptionsMenu()
    {
        homeMenu.SetActive(false);
        homeOptionsMenu.SetActive(true);
    }

    public void HomeOptionsBack()
    {
        homeMenu.SetActive(true);
        homeOptionsMenu.SetActive(false);
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
            default:
                break;
        }
    }
}


