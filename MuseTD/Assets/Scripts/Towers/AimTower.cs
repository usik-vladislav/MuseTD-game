using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AimTower : Tower
{
    protected Vector3 direction;

    protected Rigidbody2D rb;

    protected Mob target;

    protected List<Mob> enemys;

    protected override void Awake()
    {
        base.Awake();
        enemys = new List<Mob>();
    }

    protected override void Update()
    {
        base.Update();
        if (IsBuilding)
        {
            CheckEnemy();
            SetTarget();
            Rotate();
        }
    }

    private void SetTarget()
    {
        if (enemys.Count > 0)
        {
            var maxPassedWay = enemys.Max(x => x.PassedWay);
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i].PassedWay == maxPassedWay)
                {
                    target = enemys[i];
                    return;
                }
            }
        }
        else
        {
            target = null;
            IsTarget = false;
        }
    }

    private void CheckEnemy()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, range / 2);
        var newEnemys = new List<Mob>();
        for (int i = 0; i < colliders.Length; i++)
        {

            Mob mob = colliders[i].GetComponent<Mob>();
            if (mob)
            {
                newEnemys.Add(mob);
            }
        }

        IsTarget = (newEnemys.Count > 0) ? true : false;

        enemys = newEnemys;
    }

    protected virtual void Rotate()
    {

    }
}
