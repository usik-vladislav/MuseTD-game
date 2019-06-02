using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    protected float speed = 2.0f;

    [SerializeField]
    protected int cost = 10;

    [SerializeField]
    protected float lives = 1.0f;

    [SerializeField]
    protected int damage = 10;

    protected Vector3 direction;

    [SerializeField]
    protected float path = 39f;

    protected bool isStop = false;

    public bool isSlowDown = false;

    public float passedWay = 0;

    private void Update()
    {

        if (!isStop)
        {
            Move();
            if (isSlowDown && BeatManager.IsBeatFull && BeatManager.CountBeat % 4 == 3)
            {
                speed *= 2;
                isSlowDown = false;
            }
        }
        else
        {
            AttackBase();
        }
    }

    private void AttackBase()
    {
        Lives.TakeDamage(damage);
        Destroy(gameObject);
    }

    protected void Die()
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
        speed /= 2;
        isSlowDown = true;
    }

}
