using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : AimTower
{
    private CannonBall ball;

    [SerializeField]
    private Sprite spriteUpTower;

    [SerializeField]
    private Sprite spriteUpBall;

    [SerializeField]
    private float rotateSpeed = 1;

    private bool isRotate;

    protected override void Awake()
    {
        base.Awake();
        isRotate = true;
        ball = Resources.Load<CannonBall>("CannonBall");
        cost = Money.CannonTowerCost;
        rigitBody = GetComponent<Rigidbody2D>();
        rigitBody.angularVelocity = rotateSpeed;
        direction = Vector3.left;
    }

    protected override void Update()
    {
        if (BeatManager.IsBeatFull)
        {
            isRotate = !isRotate;
        }
        base.Update();
    }

    protected override void Rotate()
    {
        if (target && isRotate)
        {
            var newDirection = Vector3.RotateTowards(direction, target.transform.position - transform.position, rotateSpeed, 1f);
            rigitBody.MoveRotation(Vector3.SignedAngle(Vector3.left, newDirection, Vector3.forward));
            direction = newDirection;
        }
    }

    protected override void Attack()
    {
        if (BeatManager.IsBeatFull && BeatManager.CountBeat % 2 == 1 && target)
        {
            var newCannonBall = Instantiate(ball, transform.position + direction.normalized * 0.5f, transform.rotation);
            newCannonBall.Direction = direction;
            newCannonBall.Point = target.transform.position - transform.position;
            newCannonBall.Damage = damage;
            if (IsLvlUp)
            {
                newCannonBall.GetComponentInChildren<SpriteRenderer>().sprite = spriteUpBall;
                newCannonBall.IsLvlUp = true;
            }
        }
    }

    public override void LvlUp()
    {
        base.LvlUp();
        spriteComp.sprite = spriteUpTower;
        range *= 1.5f;
        damage *= 2;
        SellCost = 300;
    }
}
