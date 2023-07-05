using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TowerPlacer : MonoBehaviour
{
    bool towerPlaced = false;
    bool canBePlaced = true;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (towerPlaced == false)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set the distance from the camera

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = worldPosition;
        }
        

        if(Input.GetMouseButtonDown(0) && canBePlaced == true)
        {
            towerPlaced = true;
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
