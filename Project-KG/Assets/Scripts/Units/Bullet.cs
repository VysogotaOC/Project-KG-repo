using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }
    private Player _player;

    private Vector3 direction;
    private SpriteRenderer _sprite;
    public Vector3 Direction { set { direction = value; } }
    

    private void Awake()
    {
        _player = GetComponent<Player>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _sprite.flipX = direction.x < 0.0F;
        Destroy(gameObject, 1.4F);
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _player.moveSpeedBullet* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject != parent)
        {
            unit.ReceiveDamage(_player.rangeAttackDamage);
            Destroy(gameObject);
        }
    }
}

