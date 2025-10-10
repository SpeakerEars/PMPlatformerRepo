using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    GameObject player;
    public float chaseSpeed = 5.0f;
    //how close the player needs to be for the enemy to start chasing
    public float chaseTriggerDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //figure out where the player is, how far away
        //how far away is the player from me, the enemy
        //destination (player position) - starting position (enemy position)
        //gives the vector from the enemy to the player
        Vector3 chaseDir = player.transform.position - transform.position;
        //if the player is "close" chase the player
        //if they player gets within chaseTriggerDistance units away, chase the player
        if (chaseDir.magnitude < chaseTriggerDistance)
        {
            //chase the player!
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chaseSpeed;
        }
    }
}
