using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniProjectileScript : MonoBehaviour
{
    public float destructionTime;
    // Start is called before the first frame update
    void Awake()
    {
        //wait 1.5 seconds then destroy projectile
        Destroy(gameObject, destructionTime);
    }

}
