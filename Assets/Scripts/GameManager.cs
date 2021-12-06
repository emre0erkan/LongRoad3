using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
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

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void IncrementScore()
    {
        score = score + 5;
        scoreText.text = "Score: " + score;

    }


    private void Awake()
    {
        inst = this;
    }

}
