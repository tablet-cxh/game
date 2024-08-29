using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement playermovement;
    private float originalSpeed;
    private bool isSlowed;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playermovement = player.GetComponent<PlayerMovement>();
        originalSpeed = playermovement.speed;
        isSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if(!isSlowed)
            {
                SlowDown();
                isSlowed = true;
            }
            else
            {
                RestoreSpeed();
                isSlowed = false;
            }
        }
    }
    private void SlowDown()
    {
        playermovement.speed /= 2f;
    }
    private void RestoreSpeed()
    {
        playermovement.speed = originalSpeed;
    }
}
