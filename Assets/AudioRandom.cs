using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandom : MonoBehaviour
{
    public AudioSource source; //
    public AudioClip[] audioClips; //Compiles a list of audios

    public float minWaitTime; // Minimum wait time between clips
    public float maxWaitTime; // Maximum wait time between clips
    void Start()
    {
        StartCoroutine(PlaySoundAtRandomIntervals());
    }
    IEnumerator PlaySoundAtRandomIntervals()
    {
        //Loop indefinitely
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            if (audioClips.Length > 0)
            {
                source.clip = audioClips[Random.Range(0, audioClips.Length)];
                source.Play();
            }
        }
    }
}
