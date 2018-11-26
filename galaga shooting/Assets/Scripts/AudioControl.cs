using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour {

    private AudioSource audioSrc;
    public Slider musicSlider;
    private float musicVolume = 1f;

	// Use this for initialization
	void Start ()
    {
        audioSrc = GetComponent<AudioSource>();
        musicSlider.value = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Music Volume");
        //Changes the slider value to match the music/effect volume
        musicSlider.value = PlayerPrefs.GetFloat("Music Volume");
    }

    //Set only music volume
    public void SetMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("Music Volume", vol);
    }
}
