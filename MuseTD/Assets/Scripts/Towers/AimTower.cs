using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AimTower : Tower
{
    protected Vector3 direction;

    protected Rigidbody2D rigitBody;

    protected Mob target;

    protected override void Update()
    {
        base.Update();
        if (IsBuilding)
        {
            SetTarget();
            Rotate();
        }
    }

    private void SetTarget()
    {
        if (enemys.Count > 0)
        {
            var maxPassedWay = enemys.Max(x => x.passedWay);
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i].passedWay == maxPassedWay)
                {
                    target = enemys[i];
                    return;
                }
            }
        }
        else
        {
            target = null;
        }
    }

    protected virtual void Rotate()
    {

    }
}
