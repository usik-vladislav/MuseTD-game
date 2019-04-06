using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : Tower
{
    private Bullet bullet;

    private void Awake() 
    {
        bullet = Resources.Load<Bullet>("Bullet");
        rigitBody = GetComponent<Rigidbody2D>();
        direction = Vector3.left;
        cost = Money.GunTowerCost;
    }

    protected override void Rotate()
    {
        if (Target)
        {
            var newDirection = Target.transform.position - transform.position;
            rigitBody.MoveRotation(Vector3.SignedAngle(Vector3.left, newDirection, Vector3.forward));
            direction = newDirection;
        }
    }

    protected override void Shoot()
    {
        if (BeatManager.IsBeatFull && Target)
        {
            var newBullet = Instantiate(bullet, transform.position + direction.normalized * 0.8f, transform.rotation);
            newBullet.Direction = direction;
        }
    }
}
