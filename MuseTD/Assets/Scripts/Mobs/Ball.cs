using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : Mob
{
   //-- Временная реализация маршрута
    private Vector3[] route = new Vector3[] { 4 * Vector3.right, 5 * Vector3.up,  9 * Vector3.right,
                                              3 * Vector3.down, 6 * Vector3.left, 2 * Vector3.down,
                                              8 * Vector3.right, 2 * Vector3.down };
    

    private int indexOfDirection = 0;

    private float passedWayInSegment = 0;
   //--

    private void Awake()
    {
        direction = route[indexOfDirection];
    }

    private void Start()
    {
        lives = 3;
    }

    protected override void Move()
    {
        if (passedWayInSegment < route[indexOfDirection].magnitude)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            passedWayInSegment += speed * Time.deltaTime;
            passedWay += speed * Time.deltaTime;
        }
        else if (indexOfDirection + 1 < route.Length)
        {
            indexOfDirection++;
            direction = route[indexOfDirection];
            passedWayInSegment = 0;
        }
        else
        {
            isStop = true;
        }
    }

}
