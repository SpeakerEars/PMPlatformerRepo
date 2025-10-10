using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public int dropChance = 100;
    public GameObject prefab;
    float timer = 0;
    public float flashRed = 0.1f;
    //where do we want to play the sound
    AudioSource audioSource;
    //what sound do we want to play when we jump
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > flashRed)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when I am hit by a player bullet
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //play my jump sound
            if (audioSource != null && hitSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(hitSound);
            }
            //destroy the bullet
            Destroy(collision.gameObject);
            //reduce my hp
            health--;
            //turn red for a short amount of time
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            timer = 0;
            //destroy myself if I get too low in health
            if (health <= 0)
            {
                Destroy(gameObject);
                //create a random variable to determine if we should drop an item or not
                //maximum of Random.Range is exclusive, so we have to add +1
                int r = Random.Range(1, 101); //give a random variable between 1 and 100
                if (dropChance >= r)
                {
                    //drop an item!
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
            }
            
        }
    }
}
