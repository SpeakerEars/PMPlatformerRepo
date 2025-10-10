using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    //store the players health
    public float health = 10;
    float maxHealth;
    public Image healthBar;
    float Timer = 0;
    public float flashRed = 0.1f;
    //where do we want to play the sound
    AudioSource audioSource;
    //what sound do we want to play when we jump
    public AudioClip hitSound;
    //if we collide with something tagged as enemy, take damage
    //if health gets too low, we die (reload the level)
    //if we collide with something tagged as health pack, increase health
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && Timer > 1f)
        {
            if(audioSource != null && hitSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(hitSound);
            }
            Timer = 0;
            health--;
            healthBar.fillAmount = health / maxHealth;
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            if (health <= 0f)
            {
                //if health is too low, reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //if we collide with the health pack collectable
        if(collision.gameObject.tag == "HealthPack")
        {
            //increase the health value
            health++;
            healthBar.fillAmount = health / maxHealth;
            Destroy(collision.gameObject);
            //if our health is trying to exceed our max health
            if(health > maxHealth)
            {
                //cap our health at max health
                health = maxHealth;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > flashRed)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
