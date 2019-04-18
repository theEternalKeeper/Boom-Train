using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    private Rigidbody2D rb;
    bool buttonAlternate = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrainMovement();

    }

    void TrainMovement()
    {
        float vAxis = Input.GetAxisRaw("Vertical");

        if ( vAxis >= 0.60 && buttonAlternate == false)
        {
            // rb.MovePosition(transfom.position + movement);
            rb.AddForce(transform.right * speed);
            buttonAlternate = true;
        }

        if (vAxis <= -0.60 && buttonAlternate == true)
        {
            // rb.MovePosition(transfom.position + movement);
            rb.AddForce(transform.right * speed);
            buttonAlternate = false;
        }

    }
}
