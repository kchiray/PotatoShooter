using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class SoundController : MonoBehaviour {

    [SerializeField]AudioClip clip;
    [SerializeField]float delayBetweenClips;

    AudioSource source;
    bool canPlay = true;
	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play()
    {
        if (!canPlay)
            return;

        GameManager.Instance.Timer.Add(() =>
        {
            canPlay = true;
        }, delayBetweenClips);

        canPlay = false;
        source.PlayOneShot(clip);
        
    }

    public void Stop()
    {
        canPlay = false;
    }
}
