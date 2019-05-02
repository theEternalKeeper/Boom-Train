using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalScoring : MonoBehaviour
{
    public GameObject timer;
    public GameObject endScreen;
    public GameObject scoreSystem;

    public int timeMultiplier;
    public float score;

    float currentTime;

    GameTimer timeScript;

    Score endScore;

    private string nextScene;

    public string playLevel, highScore;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("GameTimer");
        timeScript = timer.GetComponent<GameTimer>();



        endScreen = GameObject.Find("GoalScreen");
        endScore = endScreen.GetComponent<Score>();

        scoreSystem = GameObject.Find("ScoreSystem");
        scoreSystem.GetComponent<ScoreSystem_Core>();

        timeMultiplier = 5;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = timeScript.currentTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score += Mathf.Round(currentTime) * (float)timeMultiplier;
            Debug.LogError(score);
            endScore.enabled = true;
        }
    }

}
