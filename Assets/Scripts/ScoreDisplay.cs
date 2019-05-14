using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    GameObject scoreSystem;
    ScoreSystem_Core scoreSystem_Core;
    Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.Find("ScoreSystem");
        scoreSystem_Core = scoreSystem.GetComponent<ScoreSystem_Core>();
        scoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Current Score: " + scoreSystem_Core.currentScore;
    }
}
