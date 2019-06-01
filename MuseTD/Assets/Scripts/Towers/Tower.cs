using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    private int objCountInPlace = 0;

    [SerializeField]
    protected TowerSetting setting;

    [SerializeField]
    protected int LvlUpCost = 100;

    [SerializeField]
    protected int SellCost = 100;

    [SerializeField]
    protected float range = 4.0f;

    protected int cost;

    protected List<Mob> enemys;

    public bool IsTarget { get; set; }

    public bool IsBuilding { get; set; }
    
    protected virtual void Awake()
    {
        setting = Resources.Load<TowerSetting>("TowerSetting");
        setting.LvlUpButton.GetComponentInChildren<Text>().text = LvlUpCost.ToString();
        setting.SellButton.GetComponentInChildren<Text>().text = SellCost.ToString();

        IsTarget = false;
        IsBuilding = false;
        enemys = new List<Mob>();
    }

    protected virtual void Update()
    {
        if (IsBuilding)
        {
            CheckEnemy();
            Attack();
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
                Money.BuyTower(cost);
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

        IsTarget = (newEnemys.Count > 1) ? true : false;

        enemys = newEnemys;
    }

    protected virtual void Attack()
    {

    }

    private void SetPos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

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

    protected void OnMouseDown()
    {
        if (IsBuilding)
        {
            Instantiate(setting, transform.position - new Vector3 (0, 0.75f, 0) , Quaternion.identity);
        }
    }
}
