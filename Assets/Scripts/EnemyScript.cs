using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    private GameObject enemyManagerObject;
    private EnemyManagerScript enemyManagerScript;

    public Vector3 targetPosition;
    public float moveSpeed = 5f;
    private Vector3 direction;



    void Awake()
    {
        enemyManagerObject = GameObject.Find("EnemyManager");
        enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
        StartCoroutine(MoveTowardsTarget());
    }
    void Update()
    {
        
    }
    private IEnumerator MoveTowardsTarget()
    {
        for (int i = 0; i < enemyManagerScript.waypointPositions.Count; i++)
        {
            Vector3 vector = enemyManagerScript.waypointPositions[i];
            

            targetPosition = enemyManagerScript.waypointPositions[i];
            direction = (targetPosition - transform.position).normalized;

            while (Vector3.Distance(transform.position, targetPosition) > .1f)
            {   
                // Move towards the target position based on the direction and moveSpeed
                transform.position += direction * moveSpeed * Time.deltaTime;
                yield return null;
                
            }
            yield return null;

        }
        
    }
    
    

}
