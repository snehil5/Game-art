using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public static AudioClip pickup, shooting;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {

        audioSrc = gameObject.GetComponent<AudioSource>();
        pickup = Resources.Load<AudioClip>("pickup");
        shooting = Resources.Load<AudioClip>("shooting");
        if(shooting == null)
        {
            Debug.Log("FAILED");
        }
        if (shooting != null)
            Debug.Log("WORKED");

    }
    // Update is called once per frame
    void Update()
    {

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


}
