using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
 
    public static GameManager inst;

    [SerializeField] public Text scoreText;

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
