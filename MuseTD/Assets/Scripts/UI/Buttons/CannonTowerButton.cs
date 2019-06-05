using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerButton : TowerButton
{
    protected override void Awake()
    {
        tower = Resources.Load<CannonTower>("CannonTower");
        cost = Money.CannonTowerCost;
        base.Awake();
    }
}
