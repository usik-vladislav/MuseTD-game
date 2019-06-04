using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : Button
{
    protected Tower tower;

    protected SpriteRenderer spriteRend;

    protected int cost;

    protected override void Awake()
    {
        base.Awake();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (!Money.EnoughMoney(cost))
        {
            spriteRend.color = Color.gray;
        }
        else
        {
            spriteRend.color = Color.white;
        }
    }

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
