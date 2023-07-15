using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    private GameObject gameManagerObject;
    private EnemyManagerScript enemyManagerScript;
    private StatsManagerScript statsManagerScript;

    private Vector2 targetPosition;
    public float moveSpeed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;



    void Awake()
    {
        gameManagerObject = GameObject.Find("GameManager");
        enemyManagerScript = gameManagerObject.GetComponent<EnemyManagerScript>();
        statsManagerScript = gameManagerObject.GetComponent<StatsManagerScript>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveTowardsTarget());
    }
    void Update()
    {
        
    }
    private IEnumerator MoveTowardsTarget()
    {
        for (int i = 0; i < enemyManagerScript.waypointPositions.Count; i++)
        {
            Vector2 vector = enemyManagerScript.waypointPositions[i];
            

            targetPosition = enemyManagerScript.waypointPositions[i];
            direction = (targetPosition - (Vector2)transform.position).normalized;

            while (Vector2.Distance(transform.position, targetPosition) > .1f)
            {   
                // Move towards the target position based on the direction and moveSpeed
                rb.velocity = direction * moveSpeed;
                yield return null;
                
            }
            yield return null;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
         // Check if collision occurs with a specific tag
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            statsManagerScript.updatePoints(1);

        }
        else if (collision.gameObject.CompareTag("EnemyDeleter"))
        {
            Destroy(gameObject);
            statsManagerScript.updateLives(-1);

        }
    }
    

}
