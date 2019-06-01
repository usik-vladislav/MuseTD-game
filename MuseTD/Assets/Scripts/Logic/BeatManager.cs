using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    private AudioSource audioSource;

    private float songPosition;

    private float secPerBeatD4;

    private float beatTimer = 0;

    private float beatTimerD4 = 0;

    private float dsptimesong;         //сколько времени (в секундах) прошло после начала песни

    [SerializeField]
    private float bpm = 180;

    public static float SecPerBeat { get; set; }

    public static float SongPosInBeats { get; set; }

    public static bool IsBeatFull { get; set; }

    public static bool IsBeatD4 { get; set; }

    public static int CountBeatD4 { get; set; }

    public static int CountBeat { get; set; }

    //[SerializeField]
    //private float offset = 0;

    //[SerializeField]
    //private float beatOffset = 0;

    //private float beatPlayTimer = 0;

    //public static bool IsBeatPlay = false;

    public void Awake()
    {
        IsBeatFull = false;
        IsBeatD4 = false;
        SecPerBeat = 60f / bpm;
        secPerBeatD4 = SecPerBeat / 4;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Global.Musik;
    }

    private void Start()
    {
        dsptimesong = (float)AudioSettings.dspTime; //+ offset; //запись времени начала песни

        audioSource.Play();

    }

    private void Update()
    {
        //IsBeatPlay = false;
        //beatPlayTimer += newSongPosition - songPosition;
        //if (beatPlayTimer > secPerBeat - beatOffset)
        //{
        //    beatPlayTimer -= secPerBeat;
        //    IsBeatPlay = true;
        //}

        IsBeatFull = false;
        IsBeatD4 = false;

        audioSource.volume = Global.Musik;

        if (!audioSource.isPlaying)
        {
            LevelEndControl.IsEnded = true;
        }

        var newSongPosition = (float)(AudioSettings.dspTime - dsptimesong);   //вычисление позиции в секундах
        beatTimer += newSongPosition - songPosition;
        beatTimerD4 += newSongPosition - songPosition;

        if (beatTimer >= SecPerBeat)
        {
            beatTimer -= SecPerBeat;
            IsBeatFull = true;
            CountBeat++;
        }

        if (beatTimerD4 >= secPerBeatD4)
        {
            beatTimerD4 -= secPerBeatD4;
            IsBeatD4 = true;
            CountBeatD4++;
        }

        songPosition = newSongPosition;
        SongPosInBeats = songPosition / SecPerBeat;
    }
}

