using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerRespawn playerRespawn;
    public GameObject defaultFlag;
    public GameObject flag;


    // Start is called before the first frame update
    void Start()
    {
        playerRespawn = GameObject.Find("Character").GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            playerRespawn.respawnPoint = transform.position;
            defaultFlag.SetActive(true);
            flag.SetActive(false);
        }
    }
}
