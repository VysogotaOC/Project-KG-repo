using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class XMovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float _area = 3.0f;
    private float _leftBorder;
    private float _rightBorder;
    bool movingRight = true;

    private void Start()
    {
        _leftBorder = transform.position.x - _area;
        _rightBorder = transform.position.x + _area;
    }
    void Update()

    {
        
        if(transform.position.x > _rightBorder)
        {
            movingRight = false;
        }
        else if(transform.position.x < _leftBorder)
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
