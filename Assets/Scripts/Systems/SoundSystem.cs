using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _musicClips;
    [SerializeField] private List<AudioClip> _sfxClips;
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;
    public static SoundSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void PlayMusic(int index)
    {
        if (_musicSource.clip != _musicClips[index])  
        {
            _musicSource.clip = _musicClips[index];
            _musicSource.Play();
        }
    }
    public void PlaySound(int index)
    {

        if (_sfxSource != null)  
        {
            _sfxSource.PlayOneShot(_sfxClips[index]);
        }
    }

    public void StopMusic()
    {
        if (_musicSource != null)
        {
            _musicSource.Stop();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        PlayMusic(scene.buildIndex);
    }
}