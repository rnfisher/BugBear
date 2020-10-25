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
                CanvasManager.instance.AddScore(1);
                Destroy(gameObject);
            }
        }

        private void IncreaseHealth()
        {

        }
    }
}

