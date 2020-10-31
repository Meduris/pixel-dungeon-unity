using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource soundFX;

    public static bool musicEnabled = true;
    public static bool soundFXEnabled = true;

    private SoundManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void toggleMusic()
    {
        musicEnabled = !musicEnabled;
        if (musicEnabled)
        {
            music.Play();
            music.mute = false;
        }
        else
        {
            music.Stop();
            music.mute = true;
        }
    }

    public void toggleSoundFX()
    {
        soundFXEnabled = !soundFXEnabled;
        if (soundFXEnabled)
            soundFX.mute = false;
        else
            soundFX.mute = true;
    }

    public void playSoundFX(AudioClip clip)
    {
        soundFX.clip = clip;
        soundFX.Play();
    }

    public void playMusic(AudioClip clip)
    {
        music.Stop();
        music.clip = clip;
        music.Play();
    }
}