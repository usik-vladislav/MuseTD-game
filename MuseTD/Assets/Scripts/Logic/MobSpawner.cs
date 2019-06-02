using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    private bool isStarted;

    private int loopNumber;

    private Ball ball;

    private void Start()
    {
        loopNumber = 1;
        isStarted = true;
        ball = Resources.Load<Ball>("Ball");
    }

    void Update()
    {
        if (isStarted && !LevelEndControl.IsEnded)
        {
            SpawnOnLoop(loopNumber);
            if (BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == 0)
            {
                loopNumber++;
            }
        }
    }

    private void SpawnOnBeat(Mob mob, int beatNumber)
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == beatNumber - 1)
        {
            Instantiate(mob, transform.position, transform.rotation);
        }
    }

    private void SpawnOnBeatD4(Mob mob, int beatNumberD4)
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 16 == beatNumberD4 - 1)
        {
            Instantiate(mob, transform.position, transform.rotation);
        }
    }

    private void SpawnOnLoop(int loop)
    {
        switch (loop)
        {
            case 2:
                {
                    for (int i = 1; i < 5; i++)
                    {
                        SpawnOnBeat(ball, i);
                    }
                    break;
                }
            case 4:
                {
                    for (int i = 1; i < 5; i++)
                    {
                        SpawnOnBeat(ball, i);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
