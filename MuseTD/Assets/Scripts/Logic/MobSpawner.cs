using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    private bool isStarted;

    private Ball ball;

    private void Start()
    {
        isStarted = true;
        ball = Resources.Load<Ball>("Ball");
    }

    void Update()
    {
        if (isStarted && BeatManager.IsBeatFull && !LevelEndControl.IsEnded)
        {
            Instantiate(ball, transform.position, transform.rotation);
        }
    }

    private void A()
    {
        LevelEndControl.IsEnded = true;
    }
}
