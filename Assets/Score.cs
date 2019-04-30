using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject goal;
    public GameObject scoreSystem;
    public GameObject player;
    public GameObject gameTimer;

    GoalScoring timePoints;
    ScoreSystem_Core score;
    PlayerController playerController;
    GameTimer gameTimer_Script;

    int totalScore;

    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("GoalZone");
        timePoints = goal.GetComponent<GoalScoring>();

        scoreSystem = GameObject.Find("ScoreSystem");
        score = scoreSystem.GetComponent<ScoreSystem_Core>();

        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        gameTimer = GameObject.Find("GameTimer");
        gameTimer_Script = gameTimer.GetComponent<GameTimer>();

        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        if (isActiveAndEnabled == true)
        {

            playerController.enabled = false;
            gameTimer_Script.enabled = false;
            totalScore = (int)timePoints.score + score.currentScore;
            scoreText.text = "Score: " + totalScore;

        }

    }
}
