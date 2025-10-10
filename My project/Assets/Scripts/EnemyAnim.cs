using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = GetComponent<Rigidbody2D>().velocity.x;
        float moveY = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Animator>().SetFloat("x", moveX);
        GetComponent<Animator>().SetFloat("y", moveY);
        if (moveX < 0)
        {
            //we're moving to the left
            //flip our sprite to the left
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
