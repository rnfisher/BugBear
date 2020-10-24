using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyByContact : MonoBehaviour
{
    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        //if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other);
            //return;
        }
        else if (other.tag == "Collectible")
        {
            return;
        }
        else if (other.tag == "Projectile")
        {
            return;
        }
        else if (other.tag == "Boundary")
        {
            return;
        }
       
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
