using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicAudioSource; // Audio source for background music
    public AudioSource SFXAudioSource;   // Audio source for sound effects

    public AudioClip[] MusicClips, SFXClips;        // Array of music clips
    public static AudioManager Instance; // Singleton instance
    private void Awake()
    {
        // Ensure that only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic("Mainmenu"); // Play the default music on start
    }

    public void PlayMusic(string name)
    {
        AudioClip audioClip = MusicClips[0];
        //AudioClip audioClip = Array.Find(MusicClips, clip => clip.name == name);
        if (MusicClips != null)
        {
            MusicAudioSource.clip = audioClip;
            MusicAudioSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        AudioClip Clip = Array.Find(SFXClips, clip => clip.name == name);
        if (Clip != null)
        {
            SFXAudioSource.PlayOneShot(Clip);
        }
    }

    public void PlayLoop(string name)
    {
        AudioClip clip = Array.Find(SFXClips, c => c.name == name);
        if (clip != null)
        {
            if (SFXAudioSource.clip == clip && SFXAudioSource.isPlaying) return; // tránh gọi lại
            SFXAudioSource.clip = clip;
            SFXAudioSource.loop = true;
            SFXAudioSource.Play();
        }
    }

    public void StopLoop()
    {
        SFXAudioSource.loop = false;
        SFXAudioSource.Stop();
    }



    public void ToggleMusic()
    {
        MusicAudioSource.mute = !MusicAudioSource.mute; // Toggle the mute state of the music audio source
    }

    public void ToggleSFX()
    {
        SFXAudioSource.mute = !SFXAudioSource.mute; // Toggle the mute state of the sound effects audio source
    }

    public void MusicVolume(float volume)
    {
        MusicAudioSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        SFXAudioSource.volume = volume;
    }
}
