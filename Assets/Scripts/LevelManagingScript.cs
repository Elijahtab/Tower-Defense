using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManagingScript : MonoBehaviour
{
    public Button levelButton;  // Reference to the button
    int levelNum = 1;
    private EnemySpawnerScript enemySpawnerScript;

    void Start()
    {
        levelNum = 1;
        enemySpawnerScript = GetComponent<EnemySpawnerScript>();
    }

    void Update()
    {
        
    }

    public void nextLevel()
    {
        levelNum += 1;
        TMP_Text levelButtonText = levelButton.GetComponentInChildren<TMP_Text>();
        levelButtonText.text = "Begin Level " + levelNum;
        enemySpawnerScript.spawnEnemies(levelNum);
        
    }
}
