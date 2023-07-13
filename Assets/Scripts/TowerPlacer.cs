using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TowerPlacer : MonoBehaviour
{
    bool towerPlaced = false;
    bool canBePlaced = true;
    private SpriteRenderer spriteRenderer;

    private BasicTowerScript basicTowerScript;
    private TowerPlacingManager towerPlacingManager;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        basicTowerScript = GetComponent<BasicTowerScript>();
        GameObject gameManager = GameObject.Find("GameManager");
        towerPlacingManager = gameManager.GetComponent<TowerPlacingManager>();


    }

    void Update()
    {
        if (towerPlaced == false)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 8f; // Set the distance from the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
            towerPlacingManager.canPlaceNewTower(false);
        }
        

        if(Input.GetMouseButtonDown(0) && canBePlaced == true && towerPlaced == false)
        {
            towerPlaced = true;
            basicTowerScript.towerIsPlaced();
            towerPlacingManager.canPlaceNewTower(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Path"))
        {
            ChangeColorToRed();
            canBePlaced = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Path"))
        {
            ChangeColorToOriginal();
            canBePlaced = true;
        }
    }
    private void ChangeColorToRed()
    {
        // Set the color of the sprite renderer to red
        spriteRenderer.color = Color.red;
    }
    private void ChangeColorToOriginal()
    {
        // Set the color of the sprite renderer to red
        spriteRenderer.color = Color.white;
    }
}
