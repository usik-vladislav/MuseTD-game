using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnergoBall : EnergoBall
{
    protected override void Update()
    {
        base.Update();
        if (BeatManager.CountBeatD4 % 8 >= 2 && BeatManager.CountBeatD4 % 8 < 6)
        {
            var pos = BeatManager.SongPosInBeats * 4;
            if (pos != 0)
            {
                speed = Mathf.Lerp(impulse, 0, (((pos - BeatManager.CountBeatD4) + (BeatManager.CountBeatD4 % 8) - 2)) / 4);
                speedRotate = Mathf.Lerp(rotateImpulse, 0, (pos - BeatManager.CountBeatD4 + (BeatManager.CountBeatD4 % 8) - 2) / 4);
            }

        }
    }
}
