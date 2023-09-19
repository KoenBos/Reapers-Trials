using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public List<AudioClip> soundEffects; // List of sound effects
    public List<AudioClip> musicTracks; // List of music tracks

    private Dictionary<string, AudioClip> soundEffectDictionary;
    private Dictionary<string, AudioClip> musicTrackDictionary;

    private void Awake()
    {
        soundEffectDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip sfx in soundEffects)
        {
            soundEffectDictionary[sfx.name] = sfx;
        }

        musicTrackDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip music in musicTracks)
        {
            musicTrackDictionary[music.name] = music;
        }
    }

    public void PlayMusic(string musicName, bool loop = true)
    {
        if (musicTrackDictionary.ContainsKey(musicName))
        {
            musicSource.clip = musicTrackDictionary[musicName];
            musicSource.loop = loop;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music track not found: " + musicName);
        }
    }

    public void PlaySFX(string sfxName)
    {
        if (soundEffectDictionary.ContainsKey(sfxName))
        {
            sfxSource.PlayOneShot(soundEffectDictionary[sfxName]);
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + sfxName);
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        sfxSource.volume = volume;
    }
}
