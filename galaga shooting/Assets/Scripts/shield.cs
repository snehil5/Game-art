/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    public GameObject cube;

    // Use this for initialization
    void Start()
    {
        cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            cube.SetActive(true);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    
    public int shieldHP;
    // public GameObject ShieldDamageEffect;
    private Animator MyAnimator;
    private shieldStart shieldbool;
    // Use this for initialization
    void Start()
    {
        shieldbool = GetComponentInParent<shieldStart>();
        MyAnimator = GetComponent<Animator>();
    }

    //Update is called once per frame

    void Update()
    {
        if (shieldHP == 0 )
        {
            shieldbool.IsShieldOn = false;
            gameObject.SetActive(false);
        }

    }

    IEnumerator HurtBlinker(float hurtTime)
    {


        MyAnimator.SetLayerWeight(1, 1f);

        yield return new WaitForSeconds(hurtTime);



        MyAnimator.SetLayerWeight(1, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy" )
        {
            //Destroy(Instantiate(ShieldDamageEffect, transform.position, Quaternion.identity), .5f);
            StartCoroutine(HurtBlinker(0.25f));
            shieldHP = 0;
            Debug.Log("SHIELD COLLISION");

        }
        if (collision.tag == "EnemyBullet" )
        {
            // Destroy(Instantiate(ShieldDamageEffect, transform.position, Quaternion.identity), .5f);
            StartCoroutine(HurtBlinker(0.5f));
            shieldHP--;
            Debug.Log("SHIELD COLLISION");

        }
        if (collision.tag == "Asteroid1" )
        {
            // Destroy(Instantiate(ShieldDamageEffect, transform.position, Quaternion.identity), .5f);
            StartCoroutine(HurtBlinker(0.25f));
            shieldHP = 0;
            Debug.Log("SHIELD COLLISION");
        }
        if (collision.tag == "Asteroid2" )
        {
            // Destroy(Instantiate(ShieldDamageEffect, transform.position, Quaternion.identity), .5f);
            StartCoroutine(HurtBlinker(0.25f));
            shieldHP = 0;
            Debug.Log("SHIELD COLLISION");
        }
    }
}
