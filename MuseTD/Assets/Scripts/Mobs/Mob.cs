using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private int indexOfDirection = 0;

    [SerializeField]
    protected float speed = 2.0f;

    [SerializeField]
    protected int cost = 10;

    [SerializeField]
    protected float lives = 1.0f;

    [SerializeField]
    protected int damage = 10;

    protected Vector3[] route = new Vector3[] { 4 * Vector3.right, 5 * Vector3.up,  9 * Vector3.right,
                                              3 * Vector3.down, 6 * Vector3.left, 2 * Vector3.down,
                                              8 * Vector3.right, 2 * Vector3.down };

    protected Vector3 direction;

    [SerializeField]
    protected float path = 39f;

    protected bool isStop = false;

    public bool isSlowDown = false;

    public float passedWay = 0;

    protected virtual void Update()
    {

        if (!isStop)
        {
            FindPos();
            Move();
            if (isSlowDown && BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == 3)
            {
                speed *= 3;
                isSlowDown = false;
            }
        }
        else
        {
            AttackBase();
        }
    }

    protected void FindPos()
    {
        var way = passedWay;
        var index = 0;
        foreach (var e in route)
        {
            if (way >= e.magnitude)
            {
                way -= e.magnitude;
                index++;
            }
            else
            {
                direction = e;
                indexOfDirection = index;
                return;
            }
        }
        isStop = true;
    }

    protected void AttackBase()
    {
        Lives.TakeDamage(damage);
        Destroy(gameObject);
    }

    protected virtual void Die()
    {
        Money.GetMoney(cost);
        Destroy(gameObject);
    }

    protected virtual void Move()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        lives -= damage;
        if (lives <= 0)
        {
            Die();
        }
    }

    public virtual void SlowDown()
    {
        speed /= 3;
        isSlowDown = true;
    }

}
