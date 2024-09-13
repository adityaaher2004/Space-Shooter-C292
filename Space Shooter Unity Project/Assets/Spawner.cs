using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 1.25f;
    [SerializeField] GameObject enemyPrefab;

    float xMin;
    float xMax;
    float ySpawn;

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randx = Random.Range(xMin, xMax);
        Instantiate(enemyPrefab, new Vector3(randx, ySpawn, 0), Quaternion.identity);
    }
}
