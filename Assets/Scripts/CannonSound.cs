using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSound : MonoBehaviour
{
    public GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sound);
    }
}

 