using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text TimerText;
    public Text ScoreText;
    public Text FinalScore;
    public Text StartText;

    public static int Score = 0;

    float initTimeVal = 300.0f;
    float timeLeft;
    private bool gamePaused = false;
    private bool gameStarted = false;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
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
            if (gameStarted)
            {
                FinalScore.text = "Final score: " + Score;
            }
            StartText.text = "Tap to start";
            Time.timeScale = 0;
        }

        if (gameStarted)
        {
            TimerText.text = "Time Left: " + Mathf.Round(timeLeft);
        }

        if (Input.GetButtonUp("Tap")) //Replace Tap with Fire1 to use the keyboard's control to pause
        {
            if (Mathf.Round(timeLeft) == 0)
            {
                InitGame();
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

    private void InitGame()
    {
        timeLeft = initTimeVal;
        Time.timeScale = 1;
        Score = 0;
        TimerText.text = "";
        FinalScore.text = "";
        StartText.text = "";
        gamePaused = false;
        gameStarted = true;
        SetScore();
    }

    void SetScore() {
        ScoreText.text = "Score: " + Score;
    }
}
