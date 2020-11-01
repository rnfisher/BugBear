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
                //anim.SetTrigger("");
                //  CanvasManager.instance.AddScore(foodPointGain);
                gameController.AddScore(scoreValue); //add score when hitting this object
                PlayerHealth.instance.GainHealth(foodHealthGain);
                Destroy(gameObject);
            }
        }
    }
}

