using pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public CustomAudioClip ambientMusic;
    public CustomAudioClip[] soundEffects;


    private AudioSource ambientMusicSource;

    void Start()
    {
        // Create audio sources and configure them
        ambientMusicSource = gameObject.AddComponent<AudioSource>();
        ambientMusicSource.clip = ambientMusic.clip;
        ambientMusicSource.volume = ambientMusic.volumn;
        ambientMusicSource.pitch = ambientMusic.pitch;
        ambientMusicSource.loop = true; // Set to true if you want ambient music to loop
        ambientMusicSource.Play();

        Init();
        AssignEvent();
    }

    private void AssignEvent()
    {
        EventManager.instance.AddListener(TypeOfEvent.WinEvent, PlayWinSFX);
        EventManager.instance.AddListener(TypeOfEvent.LoseEvent, PlayLoseSFX);
        EventManager.instance.AddListener(TypeOfEvent.MistakeEvent, playMistakeSFX);
        EventManager.instance.AddScoringListener(PlayCorrectSFX);

        EventManager.instance.AddListener(TypeOfEvent.walking, PlayWalkingSFX);
    }

    private void Init()
    {
        for(int i = 0; i < soundEffects.Length; i++) 
        {
            CustomAudioClip clip = soundEffects[i];

            var source= gameObject.AddComponent<AudioSource>();
            source.volume = clip.volumn;
            source.pitch = clip.pitch;
            source.clip = clip.clip;
            clip.source = source;

            soundEffects[i] = clip;
        }
    }

    private void PlayWalkingSFX()
    {
        PlayClip(musicState.walking);
    }

    private void PlayWinSFX()
    {
        PlayClip(musicState.win);
    }

    private void PlayLoseSFX()
    {
        PlayClip(musicState.lose);
    }

    private void playMistakeSFX()
    {
        PlayClip(musicState.mistake);
    }

    private void PlayCorrectSFX(ProblemSelector _)
    {
        PlayClip(musicState.correct);
    }

    private void PlayClip(musicState state)
    {
        foreach (var soundEffect in soundEffects)
        {
            if (soundEffect.state == state) 
            {
                soundEffect.source.Play();
                return;
            }
        }
        print("no clip to play for this event!");

    }
}

public enum musicState
{
    ambient,
    win,
    lose,
    correct,
    mistake,
    walking
}


[Serializable]
public struct CustomAudioClip
{
    public musicState state;
    [Range(0,1)]
    public float volumn;
    [Range(0, 3)]
    public float pitch;
    public AudioClip clip;
    [HideInInspector]public AudioSource source;
}