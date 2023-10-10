using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public int numEnemiesToSpawn = 0;
    public float spawnInterval = 0;
    public GameObject enemyPrefab;

    private LevelManagingScript levelManagingScript;
    private int currentSpawnCounter = 0;

    void Start()
    {
        levelManagingScript = GetComponent<LevelManagingScript>();
    }
    public void spawnEnemies(int numEnemies)
    {
        numEnemiesToSpawn = Mathf.RoundToInt(Mathf.Pow(numEnemies + 1f, 1.6f));
        spawnInterval = (float)numEnemies / Mathf.Pow(numEnemies, 1.2f);
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine()
    {
<<<<<<< Updated upstream
       
        currentSpawnCounter = 0;
        while (currentSpawnCounter < numEnemiesToSpawn + 1)
        {
           
=======

        currentSpawnCounter = 0;
        while (currentSpawnCounter < numEnemiesToSpawn + 1)
        {
>>>>>>> Stashed changes
            // Calculate the bottom-left position of the screen
            Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
            screenBottomLeft.z = -.01f;
            screenBottomLeft.y -=3f;
            screenBottomLeft.x +=2f;

            // Spawn the object at the bottom left of the screen
            Instantiate(enemyPrefab, screenBottomLeft, Quaternion.identity);
            
            currentSpawnCounter++;
            // Wait for the specified interval

            yield return new WaitForSeconds(spawnInterval);
        }
        levelManagingScript.levelFinished();
        
    }
}
