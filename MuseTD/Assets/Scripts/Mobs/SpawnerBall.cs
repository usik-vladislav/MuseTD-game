using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBall : Mob
{
    private Vector3 myDirection;

    private float speedRotate;

    private GreenEnergoBall greenEnergoBall;

    private YellowEnergoBall yellowEnergoBall;

    private RedEnergoBall redEnergoBall;

    private void Awake()
    {
        myDirection = Vector3.right;
        greenEnergoBall = Resources.Load<GreenEnergoBall>("GreenEnergoBall");
        yellowEnergoBall = Resources.Load<YellowEnergoBall>("YellowEnergoBall");
        redEnergoBall = Resources.Load<RedEnergoBall>("RedEnergoBall");
    }

    protected override void Update()
    {
        base.Update();
        var beat = BeatManager.CountBeat % 16;
        if (beat < 4 || beat > 12)
        {
            speed = 2.5f;
            speedRotate = (BeatManager.CountBeat % 16 == 0 || BeatManager.CountBeat % 16 == 3) ? 90 : -90;
        }
        else if (beat == 4)
        {
            speed = 0;
            speedRotate = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                Quaternion.Euler(0, 0, direction.normalized.y * 90 + ((direction.normalized.x == -1) ? 180 : 0)), 
                BeatManager.SongPosInBeats - BeatManager.CountBeat);
        }
        else if (beat <= 6)
        {
            speed = 0;
            speedRotate = 0;
            if (BeatManager.IsBeatFull)
            {
                Spawn(greenEnergoBall);
            }
            if (beat == 6)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(0, 0, direction.normalized.y * 90 + ((direction.normalized.x == -1) ? 180 : 0) - 120),
                    BeatManager.SongPosInBeats - BeatManager.CountBeat);
            }
        }
        else if (beat <= 8)
        {
            speed = 0;
            speedRotate = 0;
            if (BeatManager.IsBeatFull)
            {
                Spawn(yellowEnergoBall);
            }
            if (beat == 8)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(0, 0, direction.normalized.y * 90 + ((direction.normalized.x == -1) ? 180 : 0) + 120),
                    BeatManager.SongPosInBeats - BeatManager.CountBeat);
            }
        }
        else if ((beat <= 10 || beat == 12))
        {
            speed = 0;
            speedRotate = 0;
            if (BeatManager.IsBeatFull)
            {
                Spawn(redEnergoBall);
            }
        }
        else if (beat < 12 && BeatManager.IsBeatD4)
        {
            speed = 0;
            speedRotate = 0;
            Spawn(redEnergoBall);
        }
    }

    private void Spawn(Mob mob)
    {
        var newBall = Instantiate<Mob>(mob, transform.position + direction.normalized * 0.5f, transform.rotation);
        newBall.passedWay = passedWay + 0.5f;
    }

    protected override void Move()
    {
        var pos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(0, 0, speedRotate * Time.deltaTime);
        passedWay += (transform.position - pos).magnitude;
    }
}
