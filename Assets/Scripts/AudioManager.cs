using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public Sound menuSound;
    public Sound crash;
    public Sound collectCoin;
    public Sound gameOver;
    public Sound playTheme;
    public GameObject clickSound;
    public AudioSource clickAudioSource;

    // Start is called before the first frame update
    void Awake()
    {
        menuSound = sounds[0];
        crash = sounds[1];
        collectCoin = sounds[2];
        gameOver = sounds[3];
        playTheme = sounds[4];

        clickAudioSource = (AudioSource) clickSound.GetComponent("AudioSource");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        SetSoundsList();

        DontDestroyOnLoad(gameObject);

        PlaySound("PlayGame");
        PlaySound("MainTheme");

    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name != SceneManager.GetSceneByName("EndlessLevel").name)
        {
            menuSound.source.mute = false;
            playTheme.source.mute = true;

        }

        else
        {
            menuSound.source.mute = true;
            playTheme.source.mute = false;
        }        
    }

    public void SetSoundsList()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }

    public void PauseSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Pause();
        }
    }

    public void MuteMusic()
    {
        AudioListener.volume = 0;

    }

    public void UnMuteMusic()
    {
        AudioListener.volume = 1;

    }

    public void Vibrate()
    {
        Handheld.Vibrate();
    }

}
