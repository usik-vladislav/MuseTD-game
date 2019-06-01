using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTowerButton : TowerButton
{
    private void Start()
    {
        tower = Resources.Load<LavaTower>("LavaTower");
        cost = Money.LavaTowerCost;
    }
}
