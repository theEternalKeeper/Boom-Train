using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScipt : MonoBehaviour
{
    public GameObject particleeffect;
    GameObject scoreSystem;
    public int scoreValue;
    public ScoreSystem_Core scoreInput;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.Find("ScoreSystem");
        scoreInput = scoreSystem.GetComponent<ScoreSystem_Core>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            scoreInput.currentScore += scoreValue;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(particleeffect, transform.position, transform.rotation);
    }
}
