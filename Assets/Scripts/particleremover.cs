using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleremover : MonoBehaviour
{

    public float pitchmin;
    public float pitchmax;
    public AudioSource impactnoise;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        impactnoise.Play(1);
        impactnoise.pitch = Random.Range(pitchmin, pitchmax); ;


        Destroy(gameObject, time);
    }


}
