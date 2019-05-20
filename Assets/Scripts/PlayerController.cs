using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float power = 15;
    public float powerDecrease = 2;
    private Rigidbody2D rb;
    bool buttonAlternate = false;
    private float force = 0;
    public float obstacleCollision = 15;
    public float maxForce = 50;
    public float rightHeight = 3;
    public AudioSource chug1;
    public float chug1pitchH;
    public float chug1pitchL;
    public AudioSource chug2;
    public float chug2pitchH;
    public float chug2pitchL;
    public bool onTrack = false;
    public ParticleSystem smoke;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (onTrack == true)
        {
            TrainMovement();
        } 
        rb.AddForce(transform.right * force);
        force -= powerDecrease;
        if (force <= 0)
        {
            force = 0;
        }

    }

    void TrainMovement()
    {
        float vAxis = Input.GetAxisRaw("Vertical");

        if ( vAxis >= 0.60 && buttonAlternate == false)
        {
            // rb.MovePosition(transfom.position + movement);
            force += power;
            chug1.Play(1);
            chug1.pitch = Random.Range(chug1pitchL, chug1pitchH);
            smoke.Play();
            
            buttonAlternate = true;
        }

        if (vAxis <= -0.60 && buttonAlternate == true)
        {
            // rb.MovePosition(transfom.position + movement);
            force += power;
            chug2.Play(1);
            chug2.pitch = Random.Range(chug2pitchL, chug2pitchH);
            smoke.Stop();
            buttonAlternate = false;
        }

        if (force >= maxForce)
        {
            force = maxForce;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            onTrack = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            rb.AddForce(transform.right * -obstacleCollision);
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            onTrack = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            gameObject.transform.Translate(Vector3.up * -rightHeight);
            gameObject.transform.Rotate(0, 0, 180);
        }

    }
}
