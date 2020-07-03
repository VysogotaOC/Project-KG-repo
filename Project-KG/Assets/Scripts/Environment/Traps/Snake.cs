using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float _area = 3.0f;
    private float _leftBorder;
    private float _rightBorder;
    bool movingRight = true;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _leftBorder = transform.position.x - _area;
        _rightBorder = transform.position.x + _area;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()

    {
        if (transform.position.x > _rightBorder)
        {
            movingRight = false;
            _sprite.flipX = true;
        }
        else if (transform.position.x < _leftBorder)
        {
            movingRight = true;
            _sprite.flipX = false;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.ReceiveDamage(10);
        }
    }
}