using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    [SerializeField] MusicChannelSO musicChannel;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }

        // Subscribe to music channel events
        musicChannel.OnPlaySong.AddListener(PlaySong);
        musicChannel.OnChangeSong.AddListener(SetSong);
        musicChannel.OnPauseSong.AddListener(PauseSong);
    }

    private void Start()
    {
        audioSource.Play();
    }

    public void SetSong(AudioClip song)
    {
        audioSource.clip = song;
    }

    public void PlaySong()
    {
        audioSource.Play();
    }

    public void PauseSong()
    {
        audioSource.Pause();
    }
}
