using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public Transform wayPointManager; // Reference to the parent object
    public List<Vector2> waypointPositions;

    void Start()
    {   

        waypointPositions = new List<Vector2>();

        foreach (Transform child in wayPointManager)
        {
            waypointPositions.Add(child.position);
            
        }
        
    }

}
