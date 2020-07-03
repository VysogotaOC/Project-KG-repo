using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackController : MonoBehaviour
{
    private Bullet _bullet;
    private MoveController _move;
    private Player _player;
    public float _timer;


    public float timeBtwAttack;

    private void Start()
    {
        _bullet = Resources.Load<Bullet>("Bullet");
        _move = GetComponent<MoveController>();
        _player = GetComponent<Player>();
    }
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //float curTime = Time.time;
        if (_timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //State = CharState.Range_attack;
                Vector3 position = transform.position; position.y += 0.45F;
                Bullet newBullet = Instantiate(_bullet, position, _bullet.transform.rotation) as Bullet;
                newBullet.Parent = gameObject;
                newBullet.Direction = newBullet.transform.right * (_move.faceRight ? 1.0f : -1.0f);
                _timer = _player.rangeAttackCoolDown;
            }  
        }
        else { _timer -= Time.deltaTime; }
    }
}
