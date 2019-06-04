using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBall : DoubleBall
{
    protected override void Awake()
    {
        spawnedBall = Resources.Load<DoubleBall>("DoubleBall");
    }
}
