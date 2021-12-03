using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    [SerializeField] public Text scoreText;
    [SerializeField] public Text highScoreText;


    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();    
    }

    public void IncrementScore()
    {
        score = score + 5;
        scoreText.text = "Score: " + score;

        if(score > PlayerPrefs.GetInt("HighScore", 0)) 
        { 
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    private void Awake()
    {
        inst = this;
    }

}
