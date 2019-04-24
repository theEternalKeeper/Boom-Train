using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour

{   // Start is called before the first frame update   

    public float bulletSpeed = 10;
    public Rigidbody bullet;


    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }
    
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }
}



