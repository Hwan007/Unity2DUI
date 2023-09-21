using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private EventController _eventController;
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;
    private ObjectPool objectPool;

    private AudioSource musicAudioSource;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioMixerGroup _Master;
    [SerializeField] private AudioMixerGroup _BGM;
    [SerializeField] private AudioMixerGroup _Effect;
    [SerializeField] private AudioMixerGroup _UI;

    private void Awake()
    {
        Instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.outputAudioMixerGroup = _BGM;
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;

        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        if (_eventController != null)
            _eventController.OnClickEvent += PlayClick;
        if (musicClip)
            ChangeBackGroundMusic(musicClip);
    }

    public static void ChangeBackGroundMusic(AudioClip musicClip)
    {
        Instance.musicAudioSource.Stop();
        Instance.musicAudioSource.clip = musicClip;
        Instance.musicAudioSource.Play();
    }

    public static void PlayClip(AudioClip clip)
    {
        GameObject obj = Instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, Instance.soundEffectVolume, Instance.soundEffectPitchVariance);
    }

    public void PlayClick(bool isPressed)
    {
        if (isPressed)
            PlayClip(clickClip);
    }
}
