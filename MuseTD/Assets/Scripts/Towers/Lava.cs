using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public int Damage = 0;

    public float Range;

    public bool IsLvlUp = false;

    private void Update()
    {

        if (BeatManager.CountBeat % 4 == 1)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(1f, Range, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
        }
        else if (BeatManager.CountBeat % 4 == 3)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(Range, 1f, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
        }
        else if (BeatManager.CountBeat % 4 == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Mob mob = collider.GetComponent<Mob>();
        if (mob && BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 2 == 0)
        {
            if (IsLvlUp && !mob.IsSlowDown)
            {
                mob.SlowDown();
            }
            mob.TakeDamage(Damage);
        }
    }

}
