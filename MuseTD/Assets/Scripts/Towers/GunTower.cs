using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : Tower
{
    private Bullet bullet;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
        direction = Vector3.left;
        cost = Money.GunTowerCost;
    }

    protected override void Rotate()
    {
        if (Target)
        {
            var newDirection = Target.transform.position - transform.position;
            transform.rotation *= Quaternion.FromToRotation(direction, newDirection);
            direction = newDirection;
        }
    }

    protected override void Shoot()
    {
        if (BeatManager.IsBeatFull && Target)
        {
            var newBullet = Instantiate(bullet, transform.position + direction.normalized * 1f, transform.rotation);
            newBullet.Direction = direction;
        }
    }
}
