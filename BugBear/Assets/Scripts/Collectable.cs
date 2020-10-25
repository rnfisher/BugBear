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

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            tagName = this.gameObject.tag; // Use this to determine if this is food or other tag
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //anim.SetTrigger("");
                CanvasManager.instance.AddScore(foodPointGain);
                PlayerHealth.instance.GainHealth(foodHealthGain);
                Destroy(gameObject);
            }
        }
    }
}

