using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManagerScript : MonoBehaviour
{
    int points = 0;
    int lives = 10;
    public void updatePoints(int myPoints)
    {
        points += myPoints;
        //Debug.Log("Points: " + points);
    }
    
    public void updateLives(int myLives)
    {
        lives += myLives;
        //Debug.Log("Lives: " + lives);
    }
}
