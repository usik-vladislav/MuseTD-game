using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : AimTower
{
    private Bullet bullet;

    protected override void Awake() 
    {
        base.Awake();
        bullet = Resources.Load<Bullet>("Bullet");
        rigitBody = GetComponent<Rigidbody2D>();
        direction = Vector3.left;
        cost = Money.GunTowerCost;
    }

    protected override void Rotate()
    {
        if (target)
        {
            var newDirection = target.transform.position - transform.position;
            rigitBody.MoveRotation(Vector3.SignedAngle(Vector3.left, newDirection, Vector3.forward));
            direction = newDirection;
        }
    }

    protected override void Attack()
    {
        if (BeatManager.IsBeatFull && target)
        {
            var newBullet = Instantiate(bullet, transform.position + direction.normalized * 0.5f, transform.rotation);
            newBullet.Direction = direction;
        }
    }
}
