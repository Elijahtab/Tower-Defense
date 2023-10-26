using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject TowerMenu;
    public GameObject openTowerMenuButton;
    public GameObject endGameMenu;

    public TMP_Text endGamePointsText;


    private bool isPaused = false;

    private void Start()
    {
        // Ensure the menus is initially inactive
        pauseMenuCanvas.SetActive(false);

        endGameMenu.SetActive(false);

        TowerMenu.SetActive(false);
        

    }

    private void Update()
    {
        // Check for the "Escape" key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Show the pause menu
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Resume the game by setting time scale to 1
        isPaused = false;
    }

    public void openTowerManager()
    {
        TowerMenu.SetActive(true);
        openTowerMenuButton.SetActive(false);
    }

    public void closeTowerManager()
    {
        TowerMenu.SetActive(false);
        openTowerMenuButton.SetActive(true);
    }
    public void endGame(int endPoints)
    {
        endGameMenu.SetActive(true);
        endGamePointsText.text = "Total Kills:"  + endPoints;
        PauseGame();
    }
}
