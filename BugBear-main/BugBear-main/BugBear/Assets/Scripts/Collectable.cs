using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Collectable : MonoBehaviour
    {
        private string tagName;
        [SerializeField] private Animator anim;
        public static Collectable instance;
        public float foodHealthGain = 0.03f;
        public int foodPointGain = 1;

        private GameController gameController;
        public int scoreValue;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            tagName = this.gameObject.tag; // Use this to determine if this is food or other tag

            GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //This section is to detect if the object that collides with this script also has the 'GameController' script
            if (gameControllerObject != null)                                                 //And apply the values associated with that script.
            {
                //Debug.Log("CONTROLLER FOUND");
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            if (gameControllerObject == null)
            {
                //Debug.Log("Cannot find 'GameController' script");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                switch (tagName)
                {
                    case "Collectible":
                        SoundManager.instance.audioSources[4].Play();
                        break;
                    case "Double":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    case "Nuke":
                        SoundManager.instance.audioSources[6].Play();
                        break;
                    case "PowerUp":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    case "Rapid":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    case "Shield":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    case "Shot":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    case "Split":
                        SoundManager.instance.audioSources[7].Play();
                        break;
                    default:
                        break;
                }
                gameController.AddScore(scoreValue);
                PlayerHealth.instance.GainHealth(foodHealthGain);
                Destroy(gameObject);
            }
        }
    }
}

