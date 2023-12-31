using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingManager : MonoBehaviour
{
    bool canPlaceTower = true;
    private StatsManagerScript statsManagerScript;
    
    public void Start()
    {
        statsManagerScript = GetComponent<StatsManagerScript>();
    }

    public void canPlaceNewTower(bool myCanPlaceTower)
    {
        canPlaceTower = myCanPlaceTower;
    }
    

    public void InstantiateTower(GameObject towerName)
    {
        if(canPlaceTower == true)
            {
                //spawn prefab "Tower" on player mouse
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 1f; // Set the distance from the camera

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                Instantiate(towerName, worldPosition, Quaternion.identity);
            }
        
    }
    public void subtractTowerCost(int towerCost)
    {
        towerCost = towerCost/(-100);
        statsManagerScript.updatePoints(towerCost);
    }
}
