using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public static AudioClip pickup, shooting, bombExpode, menuSelect,
        bossLaser, Explosion, laserCharging, BossIntro, bossExplode;
    static AudioSource audioSrc;
    public Slider effectSlider;

    // Use this for initialization
    void Start()
    {

        audioSrc = gameObject.GetComponent<AudioSource>();
        pickup = Resources.Load<AudioClip>("pickup");
        shooting = Resources.Load<AudioClip>("shooting");
        bombExpode = Resources.Load<AudioClip>("bombExplode");
        menuSelect =  Resources.Load<AudioClip>("menuSelect");
        bossLaser = Resources.Load<AudioClip>("laser");
        Explosion = Resources.Load<AudioClip>("Explode");
        laserCharging = Resources.Load<AudioClip>("Charging");
        BossIntro = Resources.Load<AudioClip>("BossIntro");
        bossExplode = Resources.Load<AudioClip>("boss death");

        if (effectSlider != null)
        {
            effectSlider.value = 1f;
            if (shooting == null)
            {
                Debug.Log("FAILED");
            }
            if (shooting != null)
                Debug.Log("WORKED");
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Effect Volume");
        if (effectSlider != null)
        {
            effectSlider.value = PlayerPrefs.GetFloat("Effect Volume");
        }
        
    }

    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "pickup":
                audioSrc.PlayOneShot(pickup);
                break;
            case "shooting":
                audioSrc.PlayOneShot(shooting);
                break;
            case "bombExplode":
                audioSrc.PlayOneShot(bombExpode);
                break;
            case "menuSelect":
                audioSrc.PlayOneShot(menuSelect);
                break;
            case "bossLaser":
                audioSrc.PlayOneShot(bossLaser);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(Explosion);
                break;
            case "laserCharging":
                audioSrc.PlayOneShot(laserCharging);
                break;
            case "BossIntro":
                audioSrc.PlayOneShot(BossIntro);
                break;
            case "BossExplode":
                audioSrc.PlayOneShot(bossExplode);
                break;

        }
    }

    //Set only effect volume
    public void SetEffectVolume(float vol)
    {
        PlayerPrefs.SetFloat("Effect Volume", vol);
    }

}
