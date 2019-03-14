using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
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

    private float beatTimer = 0;

    public static bool IsBeatFull = false;

    private void Start()
    {
        //вычисление количества секунд в одном ударе
        //объявление bpm выполняется ниже
        secPerBeat = 60f / bpm;

        //запись времени начала песни
        dsptimesong = (float)AudioSettings.dspTime + offset;

        //начало песни
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        IsBeatFull = false;
        //вычисление позиции в секундах
        var newSongPosition = (float)(AudioSettings.dspTime - dsptimesong);
        beatTimer += newSongPosition - songPosition;
        songPosition = newSongPosition;

        //вычисление позиции в ударах
        songPosInBeats = songPosition / secPerBeat;

        if (beatTimer > secPerBeat)
        {
            beatTimer -= secPerBeat;
            IsBeatFull = true;
        }
    }
}

