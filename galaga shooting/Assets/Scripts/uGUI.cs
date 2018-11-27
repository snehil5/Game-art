using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class uGUI : MonoBehaviour
{
    public Text text;
    public Text capName, bossName;
    public Image dialogueIMG;
    public Sprite captain, boss;
    public GameObject bossHead, nextButton;
    public bool sprite = true;
    public bool talkerName = true;
    private Queue<string> scripts = new Queue<string>();

    public void Start()
    {
        //Vincent
        scripts.Enqueue("I know this is short notice");
        scripts.Enqueue("But without our best captain, we're doomed!");
        //Boss
        scripts.Enqueue("Why hello there, you will all die!");
        //Vincent
        scripts.Enqueue("If it gets a hold of us, our timeline will be erased. [speed=0.2]:(");
        //Boss
        scripts.Enqueue("Will the captain not speak? I see, it's the \'silent main character\' trope.");
        //Vincent
        scripts.Enqueue("You will be known as the universe's greatest champion if you win! Thats enough motivation right?");
        //Boss
        scripts.Enqueue("See ya in level 3!");
        //Vincent
        scripts.Enqueue("Captains, roll out!");
        ShowScript();
    }

    private void ShowScript()
    {
        if (scripts.Count <= 0)
        {
            nextButton.SetActive(true);
            return;
        }

        text.TypeText(scripts.Dequeue(), onComplete: () => Debug.Log("TypeText Complete"));
    }

    public void OnClickWindow()
    {
        if (text.IsSkippable())
        {
            text.SkipTypeText();
        }
        else
        {
            ShowScript();
            if (sprite)
            {
                dialogueIMG.sprite = boss;
                bossName.gameObject.SetActive(true);
                capName.gameObject.SetActive(false);
                bossHead.SetActive(true);
                sprite = false;
            }
            else
            {
                dialogueIMG.sprite = captain;
                capName.gameObject.SetActive(true);
                bossName.gameObject.SetActive(false);
                sprite = true;
            }
        }
    }
}
