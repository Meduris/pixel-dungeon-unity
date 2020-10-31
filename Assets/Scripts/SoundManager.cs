using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource soundFX;

    public bool musicEnabled
    {
        get => !music.mute;
        set
        {
            if (value)
            {
                music.Play();
            }
            else
            {
                music.Stop();
            }
            music.mute = !value;
        }
    }

    public bool soundFXEnabled
    {
        get => !soundFX.mute;
        set
        {
            soundFX.mute = !value;
        }
    }
    
    private SoundManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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