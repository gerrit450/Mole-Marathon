using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private static AudioSource _audioSource;
    private static MusicScript instance;

    private void Awake()
    {
        _audioSource = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void Destroy()
    {
        DestroyObject(gameObject);
    }
}
