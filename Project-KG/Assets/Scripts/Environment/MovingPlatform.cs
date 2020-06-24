using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float area = 4f;
    bool movingRight = true;


    // Update is called once per frame
    void Update()

    {
        
        if(transform.position.x > area)
        {
            movingRight = false;
        }
        else if(transform.position.x < -(area))
        {
            movingRight = true;
        }

        if(movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
