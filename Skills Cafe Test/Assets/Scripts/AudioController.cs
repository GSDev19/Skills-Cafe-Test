using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [SerializeField] private AudioSource m_MusicAudioSource;
    [SerializeField] private AudioClip m_Music;

    [Space]
    [SerializeField] private AudioSource m_VFXAudioSource;
    [SerializeField] private AudioClip m_CardClip;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        m_MusicAudioSource.clip = m_Music;
        m_MusicAudioSource.Play();
    }
    public void PlayCardSound()
    {
        m_VFXAudioSource.clip = m_CardClip;
        m_VFXAudioSource.Play();
    }



}
