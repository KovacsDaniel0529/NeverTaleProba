using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;


    public void RespawnNow()
    {
        transform.position = respawnPoint;
    }
    public void RespawnOnDead()
    {
        if (Health.totalHealth == 0)
        {
            RespawnNow();
            Health.totalHealth = 100;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            RespawnNow();
        }
    }

    private void Update()
    {
        RespawnOnDead();
        
    }
}
