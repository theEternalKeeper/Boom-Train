using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomZone : MonoBehaviour
{
     public GameObject respawnZone;
    
    // Start is called before the first frame update
    void Start()
    {
       // respawnZone = GameObject.Find("ReturnPlace");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.position = respawnZone.transform.position;
            player.transform.rotation = respawnZone.transform.rotation;
        }
        if (collision.gameObject.tag == "CannonBall")
        {
            Destroy(collision.gameObject);
        }
    }
}
