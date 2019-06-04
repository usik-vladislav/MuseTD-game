using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : Mob
{

    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        PassedWay += speed * Time.deltaTime;
    }

}
