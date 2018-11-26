using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public static AudioClip pickup, shooting;
    static AudioSource audioSrc;
    public Slider effectSlider;

    // Use this for initialization
    void Start()
    {

        audioSrc = gameObject.GetComponent<AudioSource>();
        pickup = Resources.Load<AudioClip>("pickup");
        shooting = Resources.Load<AudioClip>("shooting");
        effectSlider.value = 1f;
        if (shooting == null)
        {
            Debug.Log("FAILED");
        }
        if (shooting != null)
            Debug.Log("WORKED");

    }
    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Effect Volume");
        effectSlider.value = PlayerPrefs.GetFloat("Effect Volume");
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
        }
    }

    //Set only effect volume
    public void SetEffectVolume(float vol)
    {
        PlayerPrefs.SetFloat("Effect Volume", vol);
    }

}
