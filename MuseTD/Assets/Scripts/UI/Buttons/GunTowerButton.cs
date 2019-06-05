using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerButton : TowerButton
{
    protected override void Awake()
    {
        tower = Resources.Load<GunTower>("GunTower");
        cost = Money.GunTowerCost;
        base.Awake();
    }
}
