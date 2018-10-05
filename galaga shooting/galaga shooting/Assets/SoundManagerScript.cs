using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip FireSound;
    static AudioSource audioSrc;
	// Use this for initialization
	void Start () {

        FireSound = Resources.Load<AudioClip>("Blast");
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "1":
                audioSrc.PlayOneShot(FireSound);
                break;
        }
    }
}
