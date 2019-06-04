using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnergoBall : EnergoBall
{
    protected override void Update()
    {
        base.Update();
        if (BeatManager.CountBeat % 2 == 1)
        {
            var pos = BeatManager.SongPosInBeats;
            if (pos != 0)
            {
                speed = Mathf.Lerp(impulse, 0, pos - (float)System.Math.Truncate(pos));
                speedRotate = Mathf.Lerp(rotateImpulse, 0, pos - (float)System.Math.Truncate(pos));
            }

        }
    }
}
