using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public PlayerSpawner score;
    public int winningScore;
    private void OnGUI()
    {
        if (score.getScore() >= winningScore)
        {
            
            GUI.Label(new Rect(Screen.width / 2 -50 , Screen.height / 2 - 25, 100, 50), "Level Over! \nTotal Score:" + score.getScore());
        }

    }
}
