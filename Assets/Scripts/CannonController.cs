using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonController : MonoBehaviour
{

    public Rigidbody2D cannonRB;
    //public GameObject cannon;
    public Transform cannonRotation;
    public bool controlled;

    public GameObject shotLocation;
    public Vector2 shootLocation;
    public float RotationSpeed;
    public GameObject projectile;
    public Rigidbody2D rb;
    public Collider2D projcollider;
    public float speed;
    public float firingRate = 0.5f;
    float cannonCooldown = 1;

    private int timeoutDestructor;

    // Use this for initialization
    void Start()
    {
        cannonRotation = GetComponent<Transform>();
        cannonRB = GetComponent<Rigidbody2D>();
        //cannon = GetComponent<GameObject> ();
        controlled = true;

    }

    // Update is called once per frame
    void Update()
    {
        cannonCooldown += Time.deltaTime;
        shootLocation = new Vector2(shotLocation.transform.position.x, shotLocation.transform.position.y);
        if (controlled == true)
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(Vector3.forward * (-Input.GetAxis("Horizontal") * RotationSpeed) * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && cannonCooldown >= firingRate)
            {
                //timeoutDestructor = 1;
                Launch();
                //controlled = false;
                cannonCooldown = 0;
            }





        }
    }

    void Launch()
    {
        //cannon = GetComponent<GameObject> ();
        GameObject clone = Instantiate(projectile, shootLocation, Quaternion.identity) as GameObject;
        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        clonerb.AddRelativeForce(transform.TransformDirection(new Vector2((Mathf.Cos(transform.rotation.z * Mathf.Deg2Rad) * speed),
                                                                             (Mathf.Sin(transform.rotation.z * Mathf.Deg2Rad) * speed))),
                                                                             ForceMode2D.Impulse);
    }


}


