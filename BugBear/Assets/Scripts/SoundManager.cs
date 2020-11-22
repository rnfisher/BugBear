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
        public float masterVolume = 1f;
        private string currentScene;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            
            currentScene = SceneManager.GetActiveScene().name;

            if (volumeSlider == null)
            {
                volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
            }
            
            volumeSlider.onValueChanged.AddListener(delegate {
                UpdateMasterVolume();
            });
            
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            volumeSlider.value = masterVolume;
            PlaySceneMusic();
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

        private void PlaySceneMusic()
        {
            switch (currentScene)
            {
                case "Home":
                    audioSources[0].Play();
                    break;
                case "Level 1":
                    audioSources[0].Play();
                    break;
                case "Level 2":
                    audioSources[0].Play();
                    break;
                case "Level 3":
                    audioSources[0].Play();
                    break;
                case "Level 4":
                    audioSources[0].Play();
                    break;
                default:
                    break;
            }
        }
    }
}
