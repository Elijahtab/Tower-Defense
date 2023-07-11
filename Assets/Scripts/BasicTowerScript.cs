using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerScript : MonoBehaviour
{
    public string enemyTag = "Enemy"; // The tag of the enemy objects
    public float maxDistance = 10f; // The maximum distance to consider an enemy
    
    private float delayTimer; // Timer to track elapsed time
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public float shootingSpeedDelay = 2f; // Delay duration in seconds
    public float projectileSpeed = 10f; // Speed of the projectile

    private void Start()
    {
        Transform childTransform = transform.GetChild(0);
        Vector3 newRangeSize = new Vector3((float)(maxDistance*1.8), (float)(maxDistance*1.8), 0f);
        childTransform.localScale = newRangeSize;
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(enemy.transform.position, currentPosition);

            // Check if the enemy is within the desired distance
            if (distanceToEnemy <= maxDistance)
            {
                return enemy; // Return the first enemy found within the distance
            }
        }

        return null; // Return null if no enemy within the distance is found
    }

    private void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();
       
        
        if (delayTimer <= 0f)
            {
                // Code to execute after the delay
                if (closestEnemy == null)
                {
                    Debug.Log("No closest enemy available to shoot at.");
                    return;
                }
                else
                {
                    // Create a new projectile instance
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                    // Calculate the direction towards the closest enemy
                    Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;

                    // Set the velocity of the projectile
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.velocity = direction * projectileSpeed;
                    
                }

                delayTimer = shootingSpeedDelay; // Reset the timer for the next delay
            }
            else
            {
                delayTimer -= Time.deltaTime; // Decrease the timer by the time passed since the last frame
            }
        


        
    }

    

    
    
}
