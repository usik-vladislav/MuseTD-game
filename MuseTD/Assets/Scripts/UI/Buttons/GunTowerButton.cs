using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerButton : TowerButton
{
    private void Start()
    {
        tower = Resources.Load<GunTower>("GunTower");
        cost = Money.GunTowerCost;
    }
}
