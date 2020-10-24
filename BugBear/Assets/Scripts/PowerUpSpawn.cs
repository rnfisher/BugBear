using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject powerUp;
    public Transform powerUpPos;
    public float spawnRate;

    public float negValue;
    public float posValue;

    private float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector3 position = new Vector3(powerUpPos.position.x + Random.Range(negValue, posValue), 0, powerUpPos.position.z);
            Instantiate(powerUp, position, Quaternion.identity);
        }
    }
}
