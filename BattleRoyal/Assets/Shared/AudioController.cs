using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioController : MonoBehaviour
{
    public AudioClip footStep;
    public AudioSource audioSource;

    void FootStep()
    {
        audioSource.PlayOneShot(footStep);
    }
   
}
