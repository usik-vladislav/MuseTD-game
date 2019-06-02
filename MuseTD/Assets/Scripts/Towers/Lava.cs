using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public int Damage = 0;

    public float range;

    public bool IsLvlUp = false;

    private void Update()
    {

        if (BeatManager.CountBeat % 4 == 0)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(1f, range, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
        }
        else if (BeatManager.CountBeat % 4 == 2)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(range, 1f, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
        }
        else if (BeatManager.CountBeat % 4 == 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Mob mob = collider.GetComponent<Mob>();
        if (mob && BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 2 == 0)
        {
            if (IsLvlUp && !mob.isSlowDown)
            {
                mob.SlowDown();
            }
            mob.TakeDamage(Damage);
        }
    }

}
