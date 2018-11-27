using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SCORE : MonoBehaviour
{

    Text scoreTextUI;
    int score;
    PlayerSpawner score1; 

    public int Score
    {

        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    void UpdateScoreTextUI()
    {

        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }

    public void addScore(int points)
    {
        score = +score + score1.getScore(); 
        
    }
}


