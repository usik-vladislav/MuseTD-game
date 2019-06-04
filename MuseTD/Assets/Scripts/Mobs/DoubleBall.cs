using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBall : Ball
{
    protected Ball spawnedBall;

    [SerializeField]
    protected float speedRotate;

    protected virtual void Awake()
    {
        spawnedBall = Resources.Load<Ball>("Ball");
    }

    protected override void Update()
    {
        base.Update();
        Rotate();
    }

    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, speedRotate * Time.deltaTime);
    }

    protected override void Die()
    {
        base.Die();
        var newBall = Instantiate<Ball>(spawnedBall, transform.position - direction.normalized * 0.5f, transform.rotation);
        newBall.passedWay = passedWay - 0.5f;
        newBall = Instantiate<Ball>(spawnedBall, transform.position, transform.rotation);
        newBall.passedWay = passedWay;
    }
}
