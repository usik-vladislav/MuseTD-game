using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void Update()
    {

        if (BeatManager.CountBeat % 4 == 0)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(1f, 3f, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
        }
        else if (BeatManager.CountBeat % 4 == 2)
        {
            var pos = BeatManager.SongPosInBeats;
            transform.localScale = new Vector3(1, 1, 1) * Mathf.Lerp(3f, 1f, (pos - (float)System.Math.Truncate(pos)) / BeatManager.SecPerBeat);
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
            mob.TakeDamage(damage);
        }
    }

}
