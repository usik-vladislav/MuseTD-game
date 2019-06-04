using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnergoBall : EnergoBall
{
    protected override void Update()
    {
        base.Update();
        if (BeatManager.CountBeat % 8 >= 1 && BeatManager.CountBeat % 8 < 5)
        {
            var pos = BeatManager.SongPosInBeats;
            if (pos != 0)
            {
                speed = Mathf.Lerp(impulse, 0, (pos - (float)System.Math.Truncate(pos) + (BeatManager.CountBeat % 8) - 1) / 4);
                speedRotate = Mathf.Lerp(rotateImpulse, 0, (pos - (float)System.Math.Truncate(pos) + (BeatManager.CountBeat % 4) - 1) / 4);
            }

        }
    }
}
