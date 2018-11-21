using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int health;
    public Animator bossanim;
    

    
 
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("boss health is: " + health);
       
          
    }

   
    

   





}
