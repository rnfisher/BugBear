using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawn : MonoBehaviour
{
    public GameObject food;
    public Transform foodSpawnPos;
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
            Vector3 position = new Vector3(foodSpawnPos.position.x + Random.Range(negValue, posValue), 0, foodSpawnPos.position.z);
            Instantiate(food, position, Quaternion.identity);
        }
    }
}
