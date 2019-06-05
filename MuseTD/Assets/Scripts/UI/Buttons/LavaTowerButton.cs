using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTowerButton : TowerButton
{
    protected override void Awake()
    {
        tower = Resources.Load<LavaTower>("LavaTower");
        cost = Money.LavaTowerCost;
        base.Awake();
    }
}
