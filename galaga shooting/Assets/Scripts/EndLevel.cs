using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public PlayerSpawner score;
    public GameObject nextButton;

    private void OnGUI()
    {
        if (score.getScore() >= 115)
        {
            
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Level Over! \nTotal Score:" + score.getScore());
        }

    }
}
