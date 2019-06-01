using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : Button
{
    protected Tower tower;

    protected int cost;

    private void OnMouseUp()
    {
        if (LevelEndControl.IsEnded)
        {
            return;
        }
        if (Money.EnoughMoney(cost))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            var newTower = Instantiate<Tower>(tower, mousePos, Quaternion.identity);
            newTower.IsBuilding = false;
        }
    }
}
