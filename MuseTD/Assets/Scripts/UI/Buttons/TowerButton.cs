using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : Button
{
    protected Tower tower;

    protected SpriteRenderer spriteRend;

    protected int cost;

    public static Tower Tower;

    protected override void Awake()
    {
        Tower = null;
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
        if (Money.EnoughMoney(cost) && !Tower)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Tower = Instantiate<Tower>(tower, mousePos, Quaternion.identity);
            Tower.IsBuilding = false;
        }
    }
}
