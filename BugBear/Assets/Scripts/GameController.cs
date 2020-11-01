using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject food;
    public GameObject nuke;
    public GameObject split;
    public Vector3 enemySpawnValues;
    public Vector3 foodSpawnValues;
    public Vector3 nukeSpawnValues;
    public Vector3 splitSpawnValues;
    public int enemyCount;
    public int foodCount;
    public int nukeCount;
    public int splitCount;
    public float enemySpawnWait;
    public float enemyStartWait;
    public float enemyWaveWait;
    public float foodSpawnWait;
    public float foodStartWait;
    public float foodWaveWait;
    public float nukeSpawnWait;
    public float nukeStartWait;
    public float nukeWaveWait;
    public float splitSpawnWait;
    public float splitStartWait;
    public float splitWaveWait;

    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(SpawnFoodWaves());
        StartCoroutine(SpawnnukeWaves());
        StartCoroutine(SpawnsplitWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds(enemyStartWait);
        while (true)
        {
            for (int i = 0, j = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-enemySpawnValues.x, enemySpawnValues.x), enemySpawnValues.y, enemySpawnValues.z); //For 'x' the script will chose random numbers between x and -x
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(enemySpawnWait);
            }
            //Spawn Enemy
            yield return new WaitForSeconds(enemyWaveWait);
            //Wait
        }

    }
    IEnumerator SpawnFoodWaves()
    {
        yield return new WaitForSeconds(foodStartWait);
        while (true)
        {
            for (int i = 0, j = 0; i < foodCount; i++)
            {
                Vector3 foodspawnPosition = new Vector3(Random.Range(-foodSpawnValues.x, foodSpawnValues.x), foodSpawnValues.y, foodSpawnValues.z);
                Quaternion foodspawnRotation = Quaternion.identity;
                Instantiate(food, foodspawnPosition, foodspawnRotation);
                yield return new WaitForSeconds(foodSpawnWait);
            }
            //Spawn Food
            yield return new WaitForSeconds(foodWaveWait);
            //Wait
        }

    }
    IEnumerator SpawnnukeWaves()
    {
        yield return new WaitForSeconds(nukeStartWait);
        while (true)
        {
            for (int i = 0, j = 0; i < nukeCount; i++)
            {
                Vector3 nukespawnPosition = new Vector3(Random.Range(-nukeSpawnValues.x, nukeSpawnValues.x), nukeSpawnValues.y, nukeSpawnValues.z);
                Quaternion nukespawnRotation = Quaternion.identity;
                Instantiate(nuke, nukespawnPosition, nukespawnRotation);
                yield return new WaitForSeconds(nukeSpawnWait);
            }
            //Spawn Nuke Pickup
            yield return new WaitForSeconds(nukeWaveWait);
            //Wait
        }

    }
    IEnumerator SpawnsplitWaves()
    {
        yield return new WaitForSeconds(splitStartWait);
        while (true)
        {
            for (int i = 0, j = 0; i < splitCount; i++)
            {
                Vector3 splitspawnPosition = new Vector3(Random.Range(-splitSpawnValues.x, splitSpawnValues.x), splitSpawnValues.y, splitSpawnValues.z);
                Quaternion splitspawnRotation = Quaternion.identity;
                Instantiate(split, splitspawnPosition, splitspawnRotation);
                yield return new WaitForSeconds(splitSpawnWait);
            }
            //Spawn Split Pickup
            yield return new WaitForSeconds(splitWaveWait);
            //Wait
        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

