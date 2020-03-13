using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    AudioSource audiobreak;
    AudioSource brickded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //audiobreak = GetComponent<AudioSource>();
        //brickded = GetComponent<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        audiobreak = audios[0];
        brickded = audios[1];
        



    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (!inPlay)
        {
            transform.position = paddle.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);

        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.updateLives(-1);
            brickded.Play();
            
        }
        if (collision.CompareTag("side" ) )
        {
            audiobreak.Play ();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("block"))
        {
            Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(newExplosion.gameObject, 2f);
            gm.updateScore(collision.gameObject.GetComponent<BrickScript>().points);
            gm.updateNumberOfBricks();
            Destroy(collision.gameObject);
            audiobreak.Play ();
        }
    }
}
