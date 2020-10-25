using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject food;
    public Vector3 enemySpawnValues;
    public Vector3 foodSpawnValues;
    public int enemyCount;
    public int foodCount;
    public float enemySpawnWait;
    public float enemyStartWait;
    public float enemyWaveWait;
    public float foodSpawnWait;
    public float foodStartWait;
    public float foodWaveWait;

    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(enemyStartWait);
        while (true)
        {
            for (int i = 0, j = 0; i < enemyCount; i++,j++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-enemySpawnValues.x, enemySpawnValues.x), enemySpawnValues.y, enemySpawnValues.z); //For 'x' the script will chose random numbers between x and -x
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(enemySpawnWait);
            }
            yield return new WaitForSeconds(enemyWaveWait);

            for (int i = 0; i < foodCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-foodSpawnValues.x, foodSpawnValues.x), foodSpawnValues.y, foodSpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(food, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(foodSpawnWait);
            }
            yield return new WaitForSeconds(foodWaveWait);
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

