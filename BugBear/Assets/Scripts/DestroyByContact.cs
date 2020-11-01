using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class DestroyByContact : MonoBehaviour
    {

        public int scoreValue;
        private GameController gameController;

        void Start()
        {
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
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerHealth.instance.TakeDamage(0.1f);
                //Debug.Log("Hit");
                
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

