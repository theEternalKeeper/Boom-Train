﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Vector3 offSet;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offSet = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offSet;
    }
}
