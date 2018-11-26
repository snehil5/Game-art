using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlLvl2_1 : MonoBehaviour
{
    DamageHandler health;
    float speed;
    int noMove = 0;

    // Use this for initialization
    void Start()
    {
        health = gameObject.GetComponent<DamageHandler>();
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("the tag is " + gameObject.tag);
        //Debug.Log(transform.position.y + " is the y postiion" );
        if (gameObject.tag == "miniBoss" && noMove == 0)
        {
            updateMini();
        }
        else if(gameObject.tag != "miniBoss")
        {
            Vector2 position = transform.position;

            position = new Vector2(position.x, position.y - speed * Time.deltaTime);
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            if (transform.position.y < min.y)
            {
                Destroy(gameObject);
            }
        }
    }
    private void updateMini()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
       
        if (transform.position.y < 3.6 )
        {
            noMove++;
        }

    }
}
    
