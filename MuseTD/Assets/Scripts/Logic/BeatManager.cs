using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    //текущая позиция в песне (в секундах)
    private float songPosition;

    //текущая позиция в песне (в ударах)
    private float songPosInBeats;

    //длительность удара
    private float secPerBeat;

    //сколько времени (в секундах) прошло после начала песни
    private float dsptimesong;

    [SerializeField]
    private float bpm = 180;

    [SerializeField]
    private float offset = 0;
    
    [SerializeField]
    private float beatOffset = 0;

    private float beatTimer = 0;

    private float beatPlayTimer = 0;

    public static bool IsBeatFull = false;

    public static bool IsBeatPlay = false;

    private AudioSource audioSource;

    public void Awake()
    {
        //вычисление количества секунд в одном ударе
        //объявление bpm выполняется ниже
        secPerBeat = 60f / bpm;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Global.Musik;
    }

    private void Start()
    {
        //запись времени начала песни
        dsptimesong = (float)AudioSettings.dspTime + offset;

        //начало песни
        audioSource.Play();

    }

    private void Update()
    {
        IsBeatFull = false;
        IsBeatPlay = false;

        audioSource.volume = Global.Musik;

        //вычисление позиции в секундах
        var newSongPosition = (float)(AudioSettings.dspTime - dsptimesong);
        beatTimer += newSongPosition - songPosition;
        beatPlayTimer += newSongPosition - songPosition;
        songPosition = newSongPosition;

        //вычисление позиции в ударах
        songPosInBeats = songPosition / secPerBeat;

        if (beatTimer > secPerBeat)
        {
            beatTimer -= secPerBeat;
            IsBeatFull = true;
        }

        if (beatPlayTimer > secPerBeat - beatOffset)
        {
            beatPlayTimer -= secPerBeat;
            IsBeatPlay = true;
        }
    }
}

