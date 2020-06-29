using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackController : MonoBehaviour
{
    private Bullet _bullet;
    private MoveController _move;
    private float _timer;


    public float timeBtwAttack;

    private void Start()
    {
        _bullet = Resources.Load<Bullet>("Bullet");
        _move = GetComponent<MoveController>();
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
                Vector3 position = transform.position; position.y += 0.8F;
                Bullet newBullet = Instantiate(_bullet, position, _bullet.transform.rotation) as Bullet;
                newBullet.Parent = gameObject;
                newBullet.Direction = newBullet.transform.right * (_move.faceRight ? 1.0f : -1.0f);
                _timer = timeBtwAttack;
            }  
        }
        else { _timer -= Time.deltaTime; }
    }
}
