using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    new Rigidbody2D rigidbody;
     
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Character"))
        {
            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 1.5f);
        }
    }

    void FallPlatform()
    {
        rigidbody.isKinematic = false;
    }
    
}
