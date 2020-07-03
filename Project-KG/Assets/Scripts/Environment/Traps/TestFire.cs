using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire : MonoBehaviour
{
    public int dmg;
    private bool keks;
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        keks = false;
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            keks = true;
            StartCoroutine(ExampleCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            keks = false;
        }
    }



    IEnumerator ExampleCoroutine()
    {
        while (keks)
        {
            player.ReceiveDamage(dmg);
            yield return new WaitForSeconds(1);
        }
    }


}
