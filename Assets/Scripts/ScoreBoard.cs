using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class PlayerScore{

    public string playerName;
    public int playerScore;
    public PlayerScore (string playerName, int playerScore)

    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public string GetFormat()
    {
        return playerName+ "~5~"+playerScore;
    }
}

public class ScoreBoard : MonoBehaviour
{

    public int scoreCount =10;

    [Header("SAVE PANEL")]
    public InputField inputName;
    public InputField inputScore;

    [Header("SCORE DISPLAY")]
    public GameObject scoreObject;
    public GameObject scoreRoot;
    public Text  textName, textScore;

    static ScoreBoard scoreBoard;
    static string separator = "~5~";

    // use this for initallization
    void Start()
    {
        scoreBoard = this;
    }
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.S))
      {
        SaveScore("Ali", 100);
        SaveScore("Oskar", 50);
        SaveScore("Christoffer", 29);
        SaveScore("Chen", 30);
      }
        if (Input.GetKeyDown(KeyCode.P))
        {
            List<PlayerScore> playerScores = GetScore();
            foreach(PlayerScore p in playerScores)
        
        {
                StartCoroutine(CoShowScore());
        }
      }

    }

    public void SaveScoreNow()
    {
        SaveScore(inputName.text, int.Parse(inputScore.text));
    }
    public void ShowScore()

    {
        StartCoroutine(CoShowScore());
    }

    IEnumerator CoShowScore()
    {
        while (scoreRoot.transform.childCount>0)

        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }
        List<PlayerScore> playerScore = GetScore();

        foreach (PlayerScore score in playerScore)

        {
            textName.text = score.playerName;
            textScore.text = score.playerScore.ToString();

            GameObject instantiatedScore = Instantiate(scoreObject);
            instantiatedScore.SetActive(true);

            instantiatedScore.transform.SetParent(scoreRoot.transform);


        }

    }

    public static void SaveScore(string name, int score)
    {
        List<PlayerScore> playerScores = new List<PlayerScore>();
        for (int i =0; i<scoreBoard.scoreCount;i++)
        {
           if (PlayerPrefs.HasKey("Score"+i))

           {
                string[] scoreFormat = PlayerPrefs.GetString("Score" + i).Split(new string[] { separator }, System.StringSplitOptions.RemoveEmptyEntries);
                playerScores.Add(new PlayerScore(scoreFormat[0], int.Parse(scoreFormat[1])));
           } else

            {
            break;
            }
        }
        if (playerScores.Count<1)
        {
            PlayerPrefs.SetString("Score0", name + separator + score);
            print("ALI");
            return;
        }
        playerScores.Add(new PlayerScore(name, score));
        playerScores = playerScores.OrderByDescending(o => o.playerScore).ToList();
        for (int i = 0; i <scoreBoard.scoreCount; i++)
        {
        if (i >= playerScores.Count){break;}
            PlayerPrefs.SetString("Score" + i, playerScores[i].GetFormat());
        }
    }

    public List<PlayerScore> GetScore()
    {
        List<PlayerScore> playerScores = new List<PlayerScore>();
        for (int i =0; i<scoreBoard.scoreCount; i++)
        {
            if (PlayerPrefs.HasKey("Score+i"))
            {
                string[] scoreFormat = PlayerPrefs.GetString("Score" + i).Split(new string[] { separator }, System.StringSplitOptions.RemoveEmptyEntries);
                playerScores.Add(new PlayerScore(scoreFormat[0], int.Parse(scoreFormat[1])));
            }
            else
            {
                break;
            }
        }
        return playerScores;
    }
}
