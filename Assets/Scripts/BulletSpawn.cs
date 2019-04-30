﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;

    void FixedUpdate()
    {
        bool shoot = Input.GetButtonDown("Fire1");

        if (shoot) Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }
}
