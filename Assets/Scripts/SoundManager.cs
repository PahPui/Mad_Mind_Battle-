using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    public AudioClip[] Clips;
    private AudioSource s_audio;

	// Use this for initialization
	void Start () {
        s_audio = GetComponent<AudioSource>();
        PlayRandom();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void PlayRandom()
    {
        if (s_audio.isPlaying) return;
        s_audio.clip = Clips[Random.Range(0, Clips.Length)];
        s_audio.pitch = Random.Range(.95f, 1.05f);
        s_audio.Play();
        
    }
}

/*
var sounds: AudioClip[]; // set the array size and fill the elements with the sounds
 
 function PlayRandom(){ // call this function to play a random sound
     if (audio.isPlaying) return; // don't play a new sound while the last hasn't finished
     audio.clip = sounds[Random.Range(0,sounds.length)];
     audio.Play();
 }*/