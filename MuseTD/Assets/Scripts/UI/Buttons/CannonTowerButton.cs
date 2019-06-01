using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerButton : TowerButton
{
    private void Start()
    {
        tower = Resources.Load<CannonTower>("CannonTower");
        cost = Money.CannonTowerCost;
    }
}
