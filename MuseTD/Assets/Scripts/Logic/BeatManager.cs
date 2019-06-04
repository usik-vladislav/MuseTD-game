using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    private AudioSource audioSource;

    private float songPosition;

    private float beatTimer = 0;

    private float beatTimerD4 = 0;

    private float dsptimesong;         //сколько времени (в секундах) прошло после начала песни

    [SerializeField]
    private float bpm = 180;

    public static float SecPerBeatD4 { get; set; }

    public static float SecPerBeat { get; set; }

    public static float SongPosInBeats { get; set; }

    public static bool IsBeatFull { get; set; }

    public static bool IsBeatD4 { get; set; }

    public static int CountBeatD4 { get; set; }

    public static int CountBeat { get; set; }

    private void Awake()
    {
        IsBeatFull = false;
        IsBeatD4 = false;
        beatTimer = 0;
        beatTimerD4 = 0;
        CountBeatD4 = 0;
        CountBeat = 0;
        SecPerBeat = 60f / bpm;
        SecPerBeatD4 = SecPerBeat / 4;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Global.Musik;
    }

    private void Start()
    {
        dsptimesong = (float)AudioSettings.dspTime; 

        audioSource.Play();

    }

    private void Update()
    {
        IsBeatFull = false;
        IsBeatD4 = false;

        audioSource.volume = Global.Musik;

        if (!audioSource.isPlaying)
        {
            LevelEndControl.IsEnded = true;
        }

        var newSongPosition = (float)(AudioSettings.dspTime - dsptimesong);  
        beatTimer += newSongPosition - songPosition;
        beatTimerD4 += newSongPosition - songPosition;

        if (beatTimer >= SecPerBeat)
        {
            beatTimer -= SecPerBeat;
            CountBeat++;
            IsBeatFull = true;
        }

        if (beatTimerD4 >= SecPerBeatD4)
        {
            beatTimerD4 -= SecPerBeatD4;
            CountBeatD4++;
            IsBeatD4 = true;
        }

        songPosition = newSongPosition;
        SongPosInBeats = songPosition / SecPerBeat;
    }
}

