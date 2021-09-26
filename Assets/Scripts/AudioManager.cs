using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
    //How to play audio--> AudioManager.Current.PlayMethod();

    [Header("Audio Sources")]
    
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _lightningSFXAudioSource;
    [SerializeField] private AudioSource _rodPlaceSFXAudioSource;
    [SerializeField] private AudioSource _playerSFXAudioSource;
    [SerializeField] private AudioSource _enemySFXAudioSource;
    [SerializeField] private AudioSource _footstepAudioSource;
    [SerializeField] private AudioSource _uiAudioSource;

    [Header("Audio Clips")]

    public AudioClip titleMusicAudio;
    public AudioClip gameMusicAudio;
    public AudioClip lightningAudio;
    public AudioClip rodPlaceAudio;
    public AudioClip rodRecallAudio;
    public AudioClip playerDamageAudio;
    public AudioClip uiUnavailableAudio;
    public AudioClip[] footstepAudio;
    public AudioClip[] enemyDamageAudio;
    public AudioClip[] enemyDeathAudio;
    
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    protected override void Awake()
    {
        base.Awake();
    }
    
    private void Start()
    {
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        
        _musicAudioSource = audioSources[0];
        _lightningSFXAudioSource = audioSources[1];
        _rodPlaceSFXAudioSource = audioSources[2];
        _playerSFXAudioSource = audioSources[3];
        _enemySFXAudioSource = audioSources[4];
        _footstepAudioSource = audioSources[5];
        _uiAudioSource = audioSources[6];
        
        DontDestroyOnLoad(gameObject);
        
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        if (_musicAudioSource.clip != titleMusicAudio)
        {
            _musicAudioSource.clip = titleMusicAudio;
            _musicAudioSource.loop = true;
        
            _musicAudioSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (_musicAudioSource.clip != gameMusicAudio)
        {
            _musicAudioSource.clip = gameMusicAudio;
            _musicAudioSource.loop = true;
        
            _musicAudioSource.Play();
        }
    }

    public void PlayPlayerHitSFX()
    {
        _playerSFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _playerSFXAudioSource.clip = playerDamageAudio;
        _playerSFXAudioSource.loop = false;
    
        _playerSFXAudioSource.Play();
    }

    public void PlayEnemyHitSFX(int soundNum)
    {
        _enemySFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _enemySFXAudioSource.clip = enemyDamageAudio[soundNum];
        _enemySFXAudioSource.loop = false;
    
        _enemySFXAudioSource.Play();
    }

    public void PlayEnemyDeathSFX()
    {
        _enemySFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _enemySFXAudioSource.clip = enemyDeathAudio[0];
        _enemySFXAudioSource.loop = false;
    
        _enemySFXAudioSource.Play();
    }

    public void PlayLightningSFX()
    {
        _lightningSFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _lightningSFXAudioSource.clip = lightningAudio;
        _lightningSFXAudioSource.loop = false;
    
        _lightningSFXAudioSource.Play();
    }
    
    public void PlayRodPlaceSFX()
    {
        _rodPlaceSFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _rodPlaceSFXAudioSource.clip = rodPlaceAudio;
        _rodPlaceSFXAudioSource.loop = false;
    
        _rodPlaceSFXAudioSource.Play();
    }

    public void PlayRodRecallSFX()
    {
        _rodPlaceSFXAudioSource.pitch = Random.Range(1f, 1.5f);
        _rodPlaceSFXAudioSource.clip = rodRecallAudio;
        _rodPlaceSFXAudioSource.loop = false;
    
        _rodPlaceSFXAudioSource.Play();
    }

    public void PlayUIUnavailableSFX()
    {
        _uiAudioSource.pitch = Random.Range(1f, 1.5f);
        _uiAudioSource.clip = uiUnavailableAudio;
        _uiAudioSource.loop = false;
    
        _uiAudioSource.Play();
    }

    public void PlayFootstepSFX()
    {
        int randInt = Random.Range(0, footstepAudio.Length);
        _footstepAudioSource.pitch = Random.Range(1f, 1.5f);
        _footstepAudioSource.clip = footstepAudio[randInt];
        _footstepAudioSource.loop = false;
    
        _footstepAudioSource.Play();
    }
}