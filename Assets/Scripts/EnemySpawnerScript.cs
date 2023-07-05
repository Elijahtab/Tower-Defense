using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public int numEnemiesToSpawn = 0;
    public int spawnInterval = 0;
    public GameObject enemyPrefab;

    private int currentSpawnCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());

    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (currentSpawnCounter < numEnemiesToSpawn)
        {
            // Calculate the bottom-left position of the screen
            Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
            screenBottomLeft.z = 0f;
            screenBottomLeft.y -=3f;

            // Spawn the object at the bottom left of the screen
            Instantiate(enemyPrefab, screenBottomLeft, Quaternion.identity);
            
            currentSpawnCounter++;
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
