using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text TimerText;
    public Text ScoreText;
    public Text FinalScore;

    public static int Score = 0;

    float initTimeVal = 300.0f;
    float timeLeft;
    private bool gamePaused = false;
	// Use this for initialization
	void Start () {
        timeLeft = initTimeVal;
        SetScore();
	}
	
	// Update is called once per frame
    void Update()
    {

        if (Mathf.Round(timeLeft) > 0)
        {
            timeLeft -= Time.deltaTime;
            SetScore();
        }
        else //if (Mathf.Round(timeLeft) == 0)
        {
            ScoreText.text = "";
            FinalScore.text = "Final score: " + Score;
            Time.timeScale = 0;
        }

        TimerText.text = "Time Left: " + Mathf.Round(timeLeft);

        if (Input.GetButtonUp("Tap"))
        {
            if (Mathf.Round(timeLeft) == 0)
            {
                timeLeft = initTimeVal;
                Time.timeScale = 1;
                Score = 0;
                TimerText.text = "";
                FinalScore.text = "";
                gamePaused = false;
                SetScore();
            }
            else if (gamePaused) //Resume
            {
                FinalScore.text = "";
                Time.timeScale = 1;
                gamePaused = false;
            }
            else //Pause
            {
                FinalScore.text = "Game Paused";
                Time.timeScale = 0;
                gamePaused = true;
            }
        }
    }

    void SetScore() {
        ScoreText.text = "Score: " + Score;
    }
}
