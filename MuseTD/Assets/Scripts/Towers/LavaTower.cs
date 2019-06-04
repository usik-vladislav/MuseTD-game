using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTower : Tower
{
    private Lava lava;

    [SerializeField]
    private Sprite spriteTower;

    [SerializeField]
    private Sprite spriteLava;

    private Lava instanceLava;

    protected override void Awake()
    {
        base.Awake();
        lava = Resources.Load<Lava>("Lava");
        cost = Money.LavaTowerCost;
    }

    protected override void Attack()
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == 1)
        {
            instanceLava = Instantiate(lava, transform.position, transform.rotation);
            instanceLava.Range = range;
            instanceLava.Damage = damage;

            if (IsLvlUp)
            {
                instanceLava.GetComponentInChildren<SpriteRenderer>().sprite = spriteLava;
                instanceLava.IsLvlUp = true;
            }
        }
    }

    public override void LvlUp()
    {
        base.LvlUp();
        spriteComp.sprite = spriteTower;
        range *= 1.5f;
        sellCost = 300;
        if (instanceLava)
        {
            instanceLava.GetComponentInChildren<SpriteRenderer>().sprite = spriteLava;
        }
    }

}
