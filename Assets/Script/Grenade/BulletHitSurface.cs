using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletHitSurface : MonoBehaviour
{
    int enterTriggerCount = 0;
    bool createAttackArea = false;
    public GameObject Area;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Shadow")
        {
            enterTriggerCount += 1;
            
            if (enterTriggerCount == 2)
            {
                createAttackArea = true;
                
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Debug.Log(createAttackArea);
                Instantiate(Area,this.transform.position,Quaternion.identity);
                
            }
        }
    }
}
