using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace Player
{
    public class DestroyByContact : MonoBehaviour
    {
        public Animator animator;
        //private Rigidbody2D rigid;
        public int scoreValue;
        private GameController gameController;

        void Start()
        {
            //animator = GetComponent<Animator>();
            //rigid = GetComponent<Rigidbody2D>();
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

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                print("Space Bar");
                //animator.SetBool("DeathState", true);
                animator.SetTrigger("DeathState");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerHealth.instance.TakeDamage(0.1f);
            }
            else if (other.tag == "Boundary")
            {
                return;
            }
            else if (other.tag == "Enemy")
            {
                return;
            }
            else if (other.tag == "Collectible")
            {
                return;
            }
            else if (other.tag == "Boundary")
            {
                return;
            }
            else if (other.tag == "GameController")
            {
                return;
            }
            else if (other.tag == "Projectile")
            {
                //Debug.Log("Projectile Hit");
                gameController.AddScore(scoreValue); //add score when hitting this object
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }
            Destroy(gameObject); //If this hits anything unspecified, it will destroy itself

        }
    }
}

