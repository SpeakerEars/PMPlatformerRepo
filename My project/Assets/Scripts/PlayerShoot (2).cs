using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 10f;
    public float bulletLifetime = 2f;
    public float shootDelay = 0.5f;
    float timer = 0;
    public AudioClip slashSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //track how much time has passed
        //delta + change, difference
        //Time.deltaTime is the change/difference of time between frame updates
        //60 frames/second, 1/60 = 0.0166666s every frame
        timer += Time.deltaTime;
        //if we press the "shoot button" (left click) and enough time has passed
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            if (audioSource != null && slashSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(slashSound);
            }
            //reset our timer
            timer = 0;
            //get the mouse's position in the game
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn a bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            Debug.Log(mouseDir);
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * shootSpeed;
            Destroy(bullet, bulletLifetime);
            //play my jump sound
        }
    }
}
