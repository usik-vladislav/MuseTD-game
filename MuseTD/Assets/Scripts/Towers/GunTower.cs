using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : AimTower
{
    private Bullet bullet;

    [SerializeField]
    private Sprite sprite;

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
        Bullet newBullet = null;
        if (BeatManager.IsBeatFull && target)
        {
            newBullet = Instantiate(bullet, transform.position + direction.normalized * 0.5f, transform.rotation);
            newBullet.Direction = direction;
            newBullet.Damage = damage;
        }
        if (IsLvlUp && BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 2 == 0 && target)
        {
            bullet.transform.localScale /= 2;
            ShortShoot(1);
            ShortShoot(-1);
            bullet.transform.localScale *= 2;
        }
    }

    private void ShortShoot(int sign)
    {  
        var newBullet = Instantiate(bullet, transform.position + direction.normalized * 0.4f + sign * Vector3.Cross(direction, Vector3.forward).normalized * 0.2f, transform.rotation);
        newBullet.Direction = direction;
        newBullet.Damage = damage;
    }

    public override void LvlUp()
    {
        base.LvlUp();
        spriteComp.sprite = sprite;
        range *= 1.5f;
        SellCost = 200;
    }
}
