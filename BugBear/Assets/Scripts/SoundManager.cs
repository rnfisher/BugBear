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
        public AudioSource music;
        public AudioSource shoot;
        public AudioSource enemyDeath;
        public AudioSource playerDeath;
        public AudioSource foodCollection;
        public AudioSource collision;
        public Slider volumeSlider;
        private float masterVolume = 1f;
        private string currentScene;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;
            volumeSlider.onValueChanged.AddListener(delegate {
                UpdateVolume();
            });
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            volumeSlider.value = masterVolume;
            if (currentScene == "Level 1" || currentScene == "Level 2" || currentScene == "Level 3")
            {
                music.Play();
            }
        }

        private void UpdateVolume()
        {
            masterVolume = volumeSlider.value;
            music.volume = masterVolume;
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        }
    }

}
