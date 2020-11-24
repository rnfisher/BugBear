using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class SoundManagerMin : MonoBehaviour
    {
        public static SoundManagerMin instance;
        public AudioSource[] audioSources;
        private string currentScene;
        private float masterVolume;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            print(masterVolume);
            currentScene = SceneManager.GetActiveScene().name;
            PlaySceneMusic();
            UpdateMasterVolume();
        }

        private void UpdateMasterVolume()
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = masterVolume;
            }
        }

        private void PlaySceneMusic()
        {
            switch (currentScene)
            {
                case "LvlSelect":
                    audioSources[0].Play();
                    break;
                case "LvlTransition":
                    audioSources[1].Play();
                    break;
                default:
                    break;
            }
        }
    }
}
