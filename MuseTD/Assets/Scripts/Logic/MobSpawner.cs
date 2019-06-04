using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MobSpawner : MonoBehaviour
{
    private bool isStarted;

    private int loopNumber;

    private List<Loop> loops;

    private Ball ball;

    private DoubleBall doubleBall;

    private TripleBall tripleBall;

    private GreenEnergoBall greenEnergoBall;

    private YellowEnergoBall yellowEnergoBall;

    private RedEnergoBall redEnergoBall;

    private SpawnerBall spawnerBall;

    private void Start()
    {
        loopNumber = 0;
        isStarted = true;
        ball = Resources.Load<Ball>("Ball");
        doubleBall = Resources.Load<DoubleBall>("DoubleBall");
        tripleBall = Resources.Load<TripleBall>("TripleBall");
        greenEnergoBall = Resources.Load<GreenEnergoBall>("GreenEnergoBall");
        yellowEnergoBall = Resources.Load<YellowEnergoBall>("YellowEnergoBall");
        redEnergoBall = Resources.Load<RedEnergoBall>("RedEnergoBall");
        spawnerBall = Resources.Load<SpawnerBall>("SpawnerBall");
        LoopsConstruct();
    }

    private void Update()
    {
        if (isStarted && !LevelEndControl.IsEnded)
        {
            if (BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 16 == 1)
            {
                loopNumber++;
            }
            SpawnOnLoop();
        }
    }

    private void SpawnOnBeat(Mob mob, int beatNumber)
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == beatNumber % 4)
        {
            Instantiate(mob, transform.position, transform.rotation);
        }
    }

    private void SpawnOnBeatD4(Mob mob, int beatNumberD4)
    {
        if (BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 16 == beatNumberD4 % 16)
        {
            Instantiate(mob, transform.position, transform.rotation);
        }
    }

    private void SpawnOnLoop()
    {
        if (loopNumber <= loops.Count && loopNumber > 0)
        {
            foreach (var i in loops[loopNumber - 1].LoopD4.Select(e => e.Key))
            {
                SpawnOnBeatD4(loops[loopNumber - 1].LoopD4[i], i);
            }

            foreach (var i in loops[loopNumber - 1].LoopBeat.Select(e => e.Key))
            {
                SpawnOnBeat(loops[loopNumber - 1].LoopBeat[i], i);
            }
        }
    }

    private void LoopsConstruct()
    {
        loops = new List<Loop>();
        Loop loop = null;

        for (int j = 0; j < 2; j++) // 1.4
        {
            loops.Add(new Loop());

            loop = new Loop();
            for (int i = 1; i < 5; i++)
            {
                loop.LoopBeat.Add(i, ball);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 4; j++) // 2.4
        {
            loop = new Loop();
            for (int i = 1; i < 5; i++)
            {
                loop.LoopBeat.Add(i, ball);
            }
            loop.LoopD4.Add(6, ball);
            loop.LoopD4.Add(14, ball);
            loops.Add(loop);
        }

        for (int j = 0; j < 4; j++) // 3.4
        {
            loop = new Loop();
            for (int i = 1; i < 4; i++)
            {
                loop.LoopBeat.Add(i, ball);
            }
            loop.LoopBeat.Add(4, doubleBall);
            loop.LoopD4.Add(6, ball);
            loop.LoopD4.Add(10, ball);
            loops.Add(loop);
        }

        for (int j = 0; j < 4; j++) // 4.4
        {
            loop = new Loop();
            for (int i = 1; i < 5; i++)
            {
                loop.LoopBeat.Add(i, i % 2 == 1 ? ball : doubleBall);
            }
            for (int i = 2; i < 15; i += 4)
            {
                loop.LoopD4.Add(i,ball);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 8; j++) // 6.4
        {
            loop = new Loop();
            loop.LoopBeat.Add(1, tripleBall);
            loops.Add(loop);
        }

        for (int j = 0; j < 4; j++) //7.4
        {
            loop = new Loop();
            loop.LoopBeat.Add(1, greenEnergoBall);
            loop.LoopBeat.Add(3, greenEnergoBall);
            loops.Add(loop);
        }

        for (int j = 0; j < 3; j++) // 8.4
        {
            loop = new Loop();
            loop.LoopD4.Add(2, yellowEnergoBall);
            loop.LoopD4.Add(10, yellowEnergoBall);
            loops.Add(loop);
        }
        loops.Add(new Loop());


        for (int j = 0; j < 8; j++) // 10.4
        {
            loop = new Loop();
            if (j % 2 == 0)
            {
                loop.LoopBeat.Add(1, redEnergoBall);
            }
            if (j > 3)
            {
                loop.LoopBeat.Add(2, doubleBall);
                loop.LoopBeat.Add(3, doubleBall);
                loop.LoopBeat.Add(4, doubleBall);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 3; j++) //11.4
        {
            loop = new Loop();
            loop.LoopBeat.Add(1, doubleBall);
            loop.LoopBeat.Add(2, tripleBall);
            loop.LoopBeat.Add(3, doubleBall);
            loop.LoopBeat.Add(4, tripleBall);
            for (int i = 1; i < 17; i++)
            {
                if (i % 2 == 0)
                {
                    loop.LoopD4.Add(i, ball);
                }
            }
            loops.Add(loop);
        }
        loops.Add(new Loop());

        for (int j = 0; j < 3; j++) // 12.4
        {
            loop = new Loop();
            loop.LoopBeat.Add(1, greenEnergoBall);
            loop.LoopBeat.Add(3, greenEnergoBall);
            loop.LoopD4.Add(2, yellowEnergoBall);
            loop.LoopD4.Add(10, yellowEnergoBall);
            loops.Add(loop);
        }
        loops.Add(new Loop());

        for (int j = 0; j < 8; j++) // 14.4
        {
            loop = new Loop();
            if (j % 2 == 0)
            {
                loop.LoopBeat.Add(1, redEnergoBall);
            }
            else if (j < 7)
            {
                for (int i = 1; i < 5; i++)
                {
                    loop.LoopBeat.Add(i, tripleBall);
                }
                loop.LoopD4.Add(6, tripleBall);
                loop.LoopD4.Add(10, tripleBall);
                loop.LoopD4.Add(14, tripleBall);
            }
            else
            {
                loop.LoopBeat.Add(4, spawnerBall);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 8; j++) // 16.4
        {
            loop = new Loop();
            loops.Add(loop);
        }

        for (int j = 0; j < 8; j++) // 18.4
        {
            loop = new Loop();
            if (j < 7)
            {
                for (int i = 1; i < 5; i++)
                {
                    loop.LoopBeat.Add(i, tripleBall);
                }
            }
            else
            {
                loop.LoopBeat.Add(4, spawnerBall);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 8; j++) // 20.4
        {
            loop = new Loop();
            loops.Add(loop);
        }

        for (int j = 0; j < 8; j++) // 22.4
        {
            loop = new Loop();
            if (j % 2 == 0)
            {
                loop.LoopBeat.Add(1, redEnergoBall);
            }
            loop.LoopBeat.Add(3, greenEnergoBall);
            for (int i = 1; i < 17; i++)
            {
                loop.LoopD4.Add(i, tripleBall);
            }
            loops.Add(loop);
        }

        for (int j = 0; j < 4; j++)
        {
            loop = new Loop();
            for (int i = 1; i < 5; i++)
            {
                loop.LoopBeat.Add(i, tripleBall);
            }
            loops.Add(loop);
        }

    }
}
