using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float startTime = 120f;

    public float currentTime;

    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;

        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        timeText.text = "Time Left " + currentTime;
    }
}
