using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingManager : MonoBehaviour
{
    

    void Update()   
    {
        
    }

    public void InstantiateTower(GameObject towerName)
    {
        //spawn prefab "Tower" on player mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 1f; // Set the distance from the camera

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Instantiate(towerName, worldPosition, Quaternion.identity);
    


    }
}
