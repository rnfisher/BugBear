using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;
    private float masterVolume = 1f;
    private string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        volumeSlider.onValueChanged.AddListener(delegate {
            UpdateVolume();
        });
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        volumeSlider.value = masterVolume;
        audioSource.Play();
    }

    private void UpdateVolume()
    {
        masterVolume = volumeSlider.value;
        audioSource.volume = masterVolume;
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }
}
