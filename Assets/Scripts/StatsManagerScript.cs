using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManagerScript : MonoBehaviour
{
    int points = 0;
    int money = 300;
    public int lives = 10;

    public TMP_Text moneyText;
    public TMP_Text livesText;

    public void Start()
    {
        moneyText.text = money.ToString();
        livesText.text = lives.ToString();
    }

    public void updatePoints(int myPoints)
    {
        points += myPoints;
        money += myPoints * 100;
        moneyText.text = money.ToString();
    }
    
    public void updateLives(int myLives)
    {
        lives += myLives;
        livesText.text = lives.ToString();
    }
}
