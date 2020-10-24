using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
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
        Debug.Log("TEST");
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
