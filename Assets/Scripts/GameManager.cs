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
        highScoreText.text ="High Score:" + PlayerPrefs.GetInt("HighScore", 0).ToString();      //print the highscore at first
    }

    private void Update()
    {
        if (score < 75)
        {
            scorePerSecond = 1;
            score += scorePerSecond * Time.deltaTime;            //passive score increasing faster as we score more
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
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            score2 = (int)score;
            highScoreText.text = "High Score:" + score2.ToString();
        }
        }

    public void IncrementScore()
    {
        score = score + 5;                          //score 5 points if coin collected
        scoreText.text = "Score: " + (int)score;
    }

    private void Awake()
    {
        inst = this;
    }

}
