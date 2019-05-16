using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstPartcl : MonoBehaviour
{
    public GameObject particles;
    private void OnDestroy()
    {
        Instantiate(particles, transform.position, transform.rotation);
    }
}
