using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip overworldMusic;
    public AudioClip caveMusic;

    public AudioClip[] variousSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // This line was broken. Probably intended to play overworldMusic
        if (overworldMusic != null)
        {
            musicSource.clip = overworldMusic;
            musicSource.Play();
        }
    }

    public void PlayMusicSFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayRandomSFX(params AudioClip[] clips)
    {
        // Fix: Random.Pange → Random.Range
        // Fix: sfxSource.playOneShot → PlayOneShot
        variousSFX = clips;

        if (variousSFX.Length == 0) return;

        int index = Random.Range(0, variousSFX.Length);
        sfxSource.PlayOneShot(variousSFX[index]);
    }
}
