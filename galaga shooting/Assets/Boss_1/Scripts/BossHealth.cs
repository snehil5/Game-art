using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int health;
    Invisibility invisscript;
    DropBomb bombscript;
    GameObject mainhead;
    public int halfhp;

    void Start()
    {
        mainhead = GameObject.Find("MAINHEAD");
        invisscript = gameObject.GetComponent<Invisibility>();
        bombscript = mainhead.GetComponent<DropBomb>();
        
    }

    void Update()
    {
        if (health < halfhp)
        {
            Debug.Log("ACTIVATING FASTER BOMBS");
            bombscript.bombdelay = 1.0f;
        }

        if (health <= 0)
        {

            invisscript.enabled = false;
            bombscript.enabled = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("boss health is: " + health);
       
          
    }

   
    

   





}
