using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEntityManager : MonoBehaviour
{

    public static readonly HashSet<enemyEntityManager> Entities = new HashSet<enemyEntityManager>();
 
    void Awake()
    {
        Entities.Add(this);
        Debug.Log(this);
    }
 
    void OnDestroy()
    {
        Entities.Remove(this);
    }
 
}
