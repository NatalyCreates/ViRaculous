using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text TimerText;
    public Text ScoreText;
    public Text FinalScore;

    public static int Score = 0;

    float timeLeft = 300.0f;
    private bool timerEnded = false;
	// Use this for initialization
	void Start () {
        SetScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Round(timeLeft) > 0)
        {
            timeLeft -= Time.deltaTime;            
        }
        else //if (Mathf.Round(timeLeft) == 0)
        {
            ScoreText.text = "";
            FinalScore.text = "Final score: " + Score;
        }

        SetScore();
        TimerText.text = "Time Left: " + Mathf.Round(timeLeft);
	}

    void SetScore() {
        ScoreText.text = "Score: " + Score;
    }
}
