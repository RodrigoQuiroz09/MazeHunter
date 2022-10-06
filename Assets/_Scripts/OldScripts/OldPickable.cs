using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPickable : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
