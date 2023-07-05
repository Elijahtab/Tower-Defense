using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingManager : MonoBehaviour
{
    

    void Update()   
    {
        
    }

    public void InstantiateBasicTower(GameObject towerName)
    {
        //spawn prefab "Tower" on player mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Set the distance from the camera

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Instantiate(towerName, worldPosition, Quaternion.identity);
    


    }
}
