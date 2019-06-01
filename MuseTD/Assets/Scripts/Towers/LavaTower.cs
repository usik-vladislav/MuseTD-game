using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTower : Tower
{
    private Lava lava;

    protected override void Awake()
    {
        base.Awake();
        lava = Resources.Load<Lava>("Lava");
        cost = Money.LavaTowerCost;
    }

    protected override void Attack()
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == 0)
        {
            var newCannonBall = Instantiate(lava, transform.position, transform.rotation);
        }
    }
}
