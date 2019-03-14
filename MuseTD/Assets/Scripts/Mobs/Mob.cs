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
    protected float lives = 3.0f;

    protected Vector3 direction;

    protected bool isStop = false;

    public float passedWay = 0;

    private void Update()
    {
        if (!isStop)
        {
            Move();
        }
        else
        {
            Die();
        }
    }

    protected void Die()
    {
        Money.Count += cost;
        Destroy(gameObject);
    }

    protected virtual void Move()
    {

    }

}
