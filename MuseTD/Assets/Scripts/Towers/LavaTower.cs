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
            var newLava = Instantiate(lava, transform.position, transform.rotation);
            newLava.range = range;
            newLava.Damage = damage;

            if (IsLvlUp)
            {
                newLava.GetComponentInChildren<SpriteRenderer>().sprite = spriteLava;
                newLava.IsLvlUp = true;
            }
        }
    }

    public override void LvlUp()
    {
        base.LvlUp();
        spriteComp.sprite = spriteTower;
        range *= 1.5f;
        damage *= 2;
        SellCost = 300;
    }

}
