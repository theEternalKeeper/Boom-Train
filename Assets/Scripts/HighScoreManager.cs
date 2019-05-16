using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    int Score, HighScore;
    public Text Scoretext, HighScoretext;
    

    // Use this for initalization 

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore, 0");
    }
    

    // Update is called per frame 

    void Update()
    {
        if (Input.GetKeyDown("space"))



        {
            Score = Score + 1;

        }

        Scoretext.text = "Score:" + Score.ToString();
        HighScoretext.text = "HighScore:" + HighScore.ToString();


        if (Score > HighScore)
        {

            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);

        }

    }
}