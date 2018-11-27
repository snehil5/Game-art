
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldStart : MonoBehaviour
{

    public GameObject cube;
    public int SetshieldHP;
    public bool IsShieldOn;
    // public GameObject ShieldDamageEffect;
    private Animator MyAnimator;
    private shield protect;

    // Use this for initialization
    void Start()
    {
        protect = GetComponentInChildren<shield>();
        
        if (cube != null)
        {
            IsShieldOn = false;
            cube.SetActive(false);
        }
    }

    private void Update()
    {
        Debug.Log(IsShieldOn);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Shield")
        {
            protect.shieldHP = SetshieldHP;
            cube.SetActive(true);
            IsShieldOn = true;
        }
    }

  
    }