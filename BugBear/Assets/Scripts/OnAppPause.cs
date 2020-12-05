using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class OnAppPause : MonoBehaviour
    {
        void OnApplicationPause()
        {
            Debug.Log("Paused");
           // CanvasManager.instance.Pause();
            Time.timeScale = 0f;
        }
    }
}

