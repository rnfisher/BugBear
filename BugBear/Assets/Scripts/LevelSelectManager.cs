using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelectManager : MonoBehaviour
{
    /*public static LevelSelectManager instance;

    //private float timerValue;
    [HideInInspector] private string currentScene;
    [HideInInspector] public static string nextScene;
    private float counterTimer;
    public float counterTimerMax = 0.2f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //UnlockScreen();
        //Screen.SetResolution(1920, 1080, true);
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {

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
    }*/
}
