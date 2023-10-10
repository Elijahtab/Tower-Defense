using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniTowerScript : MonoBehaviour
{
    public string enemyTag = "Enemy"; // The tag of the enemy objects
    public float maxDistance; // The maximum distance to consider an enemy
    private bool enemyInRange;

    private float delayTimer; // Timer to track elapsed time
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public float shootingSpeedDelay; // Delay duration in seconds
    public float projectileSpeed;
    bool myTowerPlaced = false;
    public int numProjectiles;
    
    

     private void Start()
    {
        Transform childTransform = transform.GetChild(0);
        Vector3 newRangeSize = new Vector3((float)(maxDistance*1.8), (float)(maxDistance*1.8), 0f);
        childTransform.localScale = newRangeSize;
    }

    private void Awake()
    {
        myTowerPlaced = false;
    }
    
    void Update()
    {
        foreach (var obj in enemyEntityManager.Entities)
            {
                Vector2 entityPosition = new Vector2(obj.transform.position.x, obj.transform.position.y);

                float distanceToEnemy = Vector2.Distance(entityPosition, transform.position);
                if(distanceToEnemy <= maxDistance)
                {
                    enemyInRange = true;
                }
                        
            }

        if (delayTimer <= 0f && myTowerPlaced == true && enemyInRange == true)
            {
                float angleStep = 360.0f / numProjectiles;
                for (int i = 0; i < numProjectiles; i++)
                {
                    float angle = i * angleStep;
                    Vector2 spawnPosition = GetCirclePosition(angle, .2f);

                    // Instantiate the projectile at the calculated position.
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    Vector2 direction = (spawnPosition - (Vector2)transform.position).normalized;
                    rb.velocity = direction * projectileSpeed;
                }
                
                delayTimer = shootingSpeedDelay; // Reset the timer for the next delay 
                enemyInRange = false;  
            }
        else
            {
                enemyInRange = false;
                delayTimer -= Time.deltaTime; // Decrease the timer by the time passed since the last frame
            }
                
    }
        
    Vector2 GetCirclePosition(float angleDegrees, float radius)
    {
        float angleRadians = angleDegrees * Mathf.Deg2Rad;
        float x = transform.position.x + radius * Mathf.Cos(angleRadians);
        float y = transform.position.y + radius * Mathf.Sin(angleRadians);
        return new Vector2(x, y);
    }
    
    public void towerIsPlaced()
    {
        myTowerPlaced = true;
    }
}
