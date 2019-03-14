using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{

    private bool isStarted;

    private Ball ball;

    private void Awake()
    {
        isStarted = true;
        ball = Resources.Load<Ball>("Ball");
    }

    void Update()
    {
        if (isStarted & SongManager.IsBeatFull)
        {
            Instantiate(ball, transform.position, transform.rotation);
        }
    }
}
