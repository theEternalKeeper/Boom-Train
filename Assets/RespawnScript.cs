using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    GameObject player;

    public float rightHeight = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            player.transform.Translate(Vector3.up * -rightHeight);
            player.transform.Rotate(0, 0, 180);
        }
    }
}
