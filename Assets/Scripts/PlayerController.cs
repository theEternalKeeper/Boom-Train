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

    public bool onTrack = false;
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
            buttonAlternate = true;
        }

        if (vAxis <= -0.60 && buttonAlternate == true)
        {
            // rb.MovePosition(transfom.position + movement);
            force += power;
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
            gameObject.transform.Rotate(0, 0, 0);
        }

    }
}
