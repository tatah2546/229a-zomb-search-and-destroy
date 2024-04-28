using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] float setTime = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "DeleteAttackArea")
        {
            Destroy(other.gameObject);
                
        }
        
        Destroy(this.gameObject);
        
        
    }
    
}
