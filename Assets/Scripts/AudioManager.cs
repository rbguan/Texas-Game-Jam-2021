using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioManager : MonoBehaviour
    {
        //How to play audio--> AudioManager.Instance.PlayMethod();

        [Header("Audio Sources")]
        
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioSource _lightningSFXAudioSource;
        [SerializeField] private AudioSource _rodPlaceSFXAudioSource;
        [SerializeField] private AudioSource _playerSFXAudioSource;
        [SerializeField] private AudioSource _footstepAudioSource;
        [SerializeField] private AudioSource _enemySFXAudioSource;
        

        [Header("Audio Clips")]

        public AudioClip titleMusicAudio;
        public AudioClip gameMusicAudio;
        public AudioClip lightningAudio;
        public AudioClip rodPlaceAudio;
        public AudioClip playerDamageAudio;
        public AudioClip footstepAudio;
        public AudioClip[] enemyDamageAudio;
        public AudioClip[] enemyDeathAudio;
        
        private static AudioManager _instance;
        public static AudioManager Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        
        private void Start()
        {
            AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
            
            _musicAudioSource = audioSources[0];
            _lightningSFXAudioSource = audioSources[1];
            _rodPlaceSFXAudioSource = audioSources[2];
            _playerSFXAudioSource = audioSources[3];
            _enemySFXAudioSource = audioSources[4];
            
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
            if (_playerSFXAudioSource.clip != playerDamageAudio)
            {
                _playerSFXAudioSource.pitch = Random.Range(1f, 1.5f);
                _playerSFXAudioSource.clip = playerDamageAudio;
                _playerSFXAudioSource.loop = false;
            
                _playerSFXAudioSource.Play();
            }
        }

        public void PlayEnemyHitSFX(int soundNum)
        {
            if (_enemySFXAudioSource.clip != enemyDamageAudio[soundNum])
            {
                _enemySFXAudioSource.pitch = Random.Range(1f, 1.5f);
                _enemySFXAudioSource.clip = enemyDamageAudio[soundNum];
                _enemySFXAudioSource.loop = false;
            
                _enemySFXAudioSource.Play();
            }
        }

        public void PlayEnemyDeathSFX()
        {
            if (_enemySFXAudioSource.clip != enemyDeathAudio[0])
            {
                _enemySFXAudioSource.pitch = Random.Range(1f, 1.5f);
                _enemySFXAudioSource.clip = enemyDeathAudio[0];
                _enemySFXAudioSource.loop = false;
            
                _enemySFXAudioSource.Play();
            }
        }

        public void PlayLightningSFX()
        {
            if (_lightningSFXAudioSource.clip != lightningAudio)
            {
                _lightningSFXAudioSource.pitch = Random.Range(1f, 1.5f);
                _lightningSFXAudioSource.clip = lightningAudio;
                _lightningSFXAudioSource.loop = false;
            
                _lightningSFXAudioSource.Play();
            }
        }
        
        public void PlayRodPlaceSFX()
        {
            if (_rodPlaceSFXAudioSource.clip != rodPlaceAudio)
            {
                _rodPlaceSFXAudioSource.pitch = Random.Range(1f, 1.5f);
                _rodPlaceSFXAudioSource.clip = rodPlaceAudio;
                _rodPlaceSFXAudioSource.loop = false;
            
                _rodPlaceSFXAudioSource.Play();
            }
        }

        public void PlayFootstepSFX()
        {
            if (_footstepAudioSource.clip != footstepAudio)
            {
                _footstepAudioSource.pitch = Random.Range(1f, 1.5f);
                _footstepAudioSource.clip = footstepAudio;
                _footstepAudioSource.loop = false;
            
                _footstepAudioSource.Play();
            }
        }
    }
}