using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        public AudioSource[] audioSources;
        public Slider volumeSlider;
        private float masterVolume = 1f;
        private string currentScene;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            volumeSlider.onValueChanged.AddListener(delegate {
                UpdateMasterVolume();
            });
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            volumeSlider.value = masterVolume;
            if (currentScene == "Level 1" || currentScene == "Level 2" || currentScene == "Level 3")
            {
                audioSources[0].Play();
            }
        }

        private void UpdateMasterVolume()
        {
            masterVolume = volumeSlider.value;
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = masterVolume;
            }
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        } 
    }
}
