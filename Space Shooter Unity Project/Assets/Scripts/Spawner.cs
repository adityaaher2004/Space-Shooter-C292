using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float enemySpawnInterval = 1.25f;
    [SerializeField] float healthSpawnInterval = 10f;
    [SerializeField] float powerUpSpawnInterval = 2f;
    [SerializeField] float playerReactorInterval = 3f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject powerUpPrefab;

    [SerializeField] Player player;

    float xMin;
    float xMax;
    float ySpawn;

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("SpawnEnemy", 2f, enemySpawnInterval);
        InvokeRepeating("SpawnHealth", 20f, healthSpawnInterval);
        InvokeRepeating("SpawnPowerUp", 1f, powerUpSpawnInterval);
        InvokeRepeating("PlayerReactorGenerator", 1f, playerReactorInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerReactorGenerator()
    {
        player.givePowerUp(player.maxHealthLevel);
    }

    void SpawnEnemy()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(enemyPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }

    void SpawnHealth()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(healthPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }

    void SpawnPowerUp()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(powerUpPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }
}
