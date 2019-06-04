using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergoBall : Mob
{
    [SerializeField]
    protected float impulse;

    [SerializeField]
    protected float rotateImpulse;

    protected float speedRotate;

    protected override void Move()
    {
        var pos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(0, 0, speedRotate * Time.deltaTime);
        passedWay += (transform.position - pos).magnitude;
    }
}
