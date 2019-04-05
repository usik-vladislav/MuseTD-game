using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    protected float range = 4.0f;

    protected int cost;

    protected List<Mob> enemys;

    protected Vector3 direction;

    private int objCountInPlace = 0;

    public Mob Target { get; private set; }

    public bool IsBuilding { get; set; }
    
    private void Awake()
    {
        IsBuilding = false;
        enemys = new List<Mob>();
        Target = null;
    }

    private void Update()
    {
        if (IsBuilding)
        {
            CheckEnemy();
            SetTarget();
            Rotate();
            Shoot();
        }
        else
        {
            SetPos();
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
            
            if (Input.GetMouseButtonDown(0) && CheckObstacle())
            {
                Money.Count -= cost;
                IsBuilding = true;
                TowerManager.AddTower(this);
            }
        }
    }

    private void CheckEnemy()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, range);
        var newEnemys = new List<Mob>();
        for (int i = 0; i < colliders.Length; i++)
        {
        
            Mob mob = colliders[i].GetComponent<Mob>();
            if (mob)
            {
                newEnemys.Add(mob);
            }
        }

        enemys = newEnemys;
    }

    private void SetTarget()
    {
        if (enemys.Count > 0)
        {
            var maxPassedWay = enemys.Max(x => x.passedWay);
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i].passedWay == maxPassedWay)
                {
                    Target = enemys[i];
                    return;
                }
            }
        }
        else
        {
            Target = null;
        }
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Rotate()
    {

    }

    private void SetPos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    //private bool CheckPos()
    //{
    //    var colliders = Physics2D.OverlapCircleAll(transform.position, 1);
    //    colliders.Where(x => x.name == "Tower");
    //    return (colliders.Length < 2) ? true : false;
    //}

    private bool CheckObstacle()
    {
        return objCountInPlace > 0 ? false : true;       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (!bullet)
        {
            objCountInPlace++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (!bullet)
        {
            objCountInPlace--;
        }
    }

}
