using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    public int score2;
    public static GameManager inst;
    public float scorePerSecond;

    [SerializeField] public Text scoreText;
    [SerializeField] public Text highScoreText;


    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (score < 75)
        {
            scorePerSecond = 1;
            score += scorePerSecond * Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
        }
        else if (score > 75 && score < 125)
        {
            scorePerSecond = 4;
            score += scorePerSecond * Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
        }
        else if (score > 125)
        {
            scorePerSecond = 8;
            score += scorePerSecond * Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
        }
    }

    public void IncrementScore()
    {
        score = score + 5;
        scoreText.text = "Score: " + (int)score;

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            score2 = (int)score;
            highScoreText.text = score2.ToString();
        }
    }

    private void Awake()
    {
        inst = this;
    }

}
