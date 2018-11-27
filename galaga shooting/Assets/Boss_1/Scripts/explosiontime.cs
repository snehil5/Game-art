using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiontime : MonoBehaviour {
    GameObject BOSS;
    GameObject explosion0;
    GameObject explosion1;
    GameObject explosion2;
    GameObject explosion3;
    GameObject explosion4;
    GameObject explosion5;
    GameObject explosion6;
    GameObject explosion7;
    GameObject explosion8;
    GameObject explosion9;
    GameObject explosion10;
    GameObject explosion11;
    GameObject explosion12;
    
    

    BossHealth bosshp;
    double timeofexplosion = 600;
    public GameObject explosion;
    public GameObject fullexplosion;
    public double timetoexplode;
    GameObject CameraObject;
    CamerShake shakescript;
    

    void Start()
    {
        BOSS = GameObject.Find("Boss1");
        bosshp = BOSS.GetComponent<BossHealth>();

        CameraObject = GameObject.Find("CameraShake");
        shakescript = CameraObject.GetComponent<CamerShake>();

        



    }

    void Update()
    {
        explosion0 = GameObject.Find("DestroyBossEffect (0)(Clone)");
        explosion1 = GameObject.Find("DestroyBossEffect (1)(Clone)");
        explosion2 = GameObject.Find("DestroyBossEffect (2)(Clone)");
        explosion3 = GameObject.Find("DestroyBossEffect (3)(Clone)");
        explosion4 = GameObject.Find("DestroyBossEffect (4)(Clone)");
        explosion5 = GameObject.Find("DestroyBossEffect (5)(Clone)");
        explosion6 = GameObject.Find("DestroyBossEffect (6)(Clone)");
        explosion7 = GameObject.Find("DestroyBossEffect (7)(Clone)");
        explosion8 = GameObject.Find("DestroyBossEffect (8)(Clone)");
        explosion9 = GameObject.Find("DestroyBossEffect (9)(Clone)");
        explosion10 = GameObject.Find("DestroyBossEffect (10)(Clone)");
        explosion11 = GameObject.Find("DestroyBossEffect (11)(Clone)");
        explosion12 = GameObject.Find("DestroyBossEffect (12)(Clone)");

        if (bosshp.health <= 0)
        {
            Debug.Log("EXPLOSION TIME: " + timeofexplosion);
            timeofexplosion -= 1;
        }


        if (timeofexplosion == timetoexplode)
        {
            Instantiate(explosion, transform.position, transform.rotation); //SMALL EXPLOSIONS ON BOSS
            Audio.PlaySound("BossExplode");
            shakescript.Shake();
        }

        if (timeofexplosion < 0)
        {
           
           shakescript.Shake();
            
           
            
        }

        if (timeofexplosion == -5)
        {
            
            Destroy(explosion0);
            Destroy(explosion1);
            Destroy(explosion2);
            Destroy(explosion3);
            Destroy(explosion4);
            Destroy(explosion5);
            Destroy(explosion6);
            Destroy(explosion7);
            Destroy(explosion8);
            Destroy(explosion9);
            Destroy(explosion10);
            Destroy(explosion11);
            Destroy(explosion12);

            Destroy(Instantiate(fullexplosion, transform.position, transform.rotation), 3.0f);   //BIG EXPLOSION ON BOSS
            Audio.PlaySound("BossExplode");
            Destroy(BOSS);

        }

    }

    
}
