using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "newMusicChannel", menuName = "New Music Channel")]
public class MusicChannelSO : ScriptableObject
{
    public AudioClip CurrentSong => currentSong;
    AudioClip currentSong;
    public UnityEvent OnPlaySong;
    public UnityEvent<AudioClip> OnChangeSong;
    public UnityEvent OnPauseSong;

    public void PlaySong()
    {
        OnPlaySong.Invoke();
    }

    public void RequestSong(AudioClip song)
    {
        currentSong = song;
        OnChangeSong?.Invoke(song);
    }

    public void PauseSong()
    {
        OnPauseSong.Invoke();
    }

}
