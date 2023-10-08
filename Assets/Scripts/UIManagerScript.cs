using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject TowerMenu;
    public GameObject openTowerMenuButton;


    private bool isPaused = false;

    private void Start()
    {
        // Ensure the pause menu is initially inactive
        pauseMenuCanvas.SetActive(false);

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
}
