using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAbilities : MonoBehaviour
{
    private Player player;
    private float _timer;



    [SerializeField]
    public float healCoolDown = 2.0F;
    [SerializeField]
    private float amountOfHeal = 10.0F;

    public float lastHealTime = 0.0F;

    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentAbility();
        }
    }

    public void CurrentAbility()
    {
       
        if (Time.time - lastHealTime >= healCoolDown)
        {

            // Debug.Log(player.hp);
            if (player.GetComponent<Player>())
            {
                player.GetComponent<Player>().HealDamage(amountOfHeal, player.MaxHealthPoint);
            }
            lastHealTime = Time.time;
        }
    }
}
