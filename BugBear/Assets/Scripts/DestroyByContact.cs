using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //This section is to detect if the object that collides with this script also has the 'GameController' script
        if (gameControllerObject != null)                                                 //And apply the values associated with that script.
        {
            Debug.Log("CONTROLLER FOUND");
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
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
        gameController.AddScore(scoreValue); //add score when destroyed
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
