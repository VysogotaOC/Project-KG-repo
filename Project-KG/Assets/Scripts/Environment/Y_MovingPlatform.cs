using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float _area = 4f;
    private float _topBorder;
    private float _lowBorder;
    bool movingRight = true;

    private void Start()
    {
        _lowBorder = transform.position.y - _area;
        _topBorder = transform.position.y + _area;
    }
    void Update()

    {

        if (transform.position.y > _topBorder)
        {
            movingRight = false;
        }
        else if (transform.position.y < _lowBorder)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - speed * Time.deltaTime);
        }
    }
}
