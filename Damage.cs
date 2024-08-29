using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    private PlayerState playerHP;
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
            if(playerHP != null)
            {
                playerHP.DamagePlayer(damage);
            }
        }
    }
}
