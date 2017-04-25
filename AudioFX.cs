using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour {


    public AudioClip[] arrayAudioClips;
    public AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void reproducirChoque()
    {
        audioS.clip = arrayAudioClips[0];

        audioS.volume = 100;
        audioS.Play();

    }


    public void reproducirAcierto() {
        audioS.clip = arrayAudioClips[2];
        audioS.volume = 0.5f;
        audioS.Play();
    }


    public void reproducirMusica()
    {
       audioS.clip = arrayAudioClips[1];
        audioS.volume = 0.5f;
       audioS.Play();
    }
}
        

 
