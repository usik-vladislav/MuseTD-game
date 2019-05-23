using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerButton : Button
{
    private GunTower tower;

    private new void Awake()
    {
        base.Awake();
        tower = Resources.Load<GunTower>("GunTower");
    }

    private void OnMouseUp()
    {
        if (Money.EnoughMoney(Money.GunTowerCost))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            var newTower = Instantiate<GunTower>(tower, mousePos, Quaternion.identity);
            newTower.IsBuilding = false;
        }
    }
}
