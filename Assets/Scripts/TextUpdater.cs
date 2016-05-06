using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text TimerText;
    public Text ScoreText;

    public static int Score = 0;

    float timeLeft = 300.0f;
	// Use this for initialization
	void Start () {
        SetScore();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        TimerText.text = "Time Left: " + Mathf.Round(timeLeft);
        if (Mathf.Round(timeLeft) == 0)
        {
            //Code to show final score
        }

	}

    void SetScore() {
        ScoreText.text = "Score: " + Score;
    }
}
