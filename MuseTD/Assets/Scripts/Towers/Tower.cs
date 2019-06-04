using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    private int objCountInPlace = 0;

    private bool onTrigger;

    protected TowerSetting setting;

    protected SpriteRenderer spriteComp;

    public bool IsLvlUp;

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected GameObject rangePlace;

    public int LvlUpCost = 100;

    [SerializeField]
    protected int SellCost = 100;

    [SerializeField]
    protected float range = 0;

    protected int cost;

    public bool IsTarget { get; set; }

    public bool IsBuilding { get; set; }

    public bool IsSelled { get; set; }
    
    protected virtual void Awake()
    {
        setting = Resources.Load<TowerSetting>("TowerSetting");
        spriteComp = GetComponentInChildren<SpriteRenderer>();

        IsTarget = false;
        IsSelled = false;
        IsBuilding = false;
        IsLvlUp = false;
        onTrigger = false;
    }

    protected virtual void Update()
    {
        rangePlace.transform.localScale = Vector3.one * range;

        if (IsSelled)
        {
            Money.GetMoney(SellCost);
            TowerManager.RemoveTower(this);
            Destroy(gameObject);
        }
        if (IsBuilding)
        {
            Attack();

            if (Input.GetMouseButtonUp(0))
            {
                if (onTrigger)
                {
                    onTrigger = false;
                }
                else
                {
                    rangePlace.SetActive(false);
                }
            }
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
                Money.Pay(cost);
                IsBuilding = true;
                TowerManager.AddTower(this);
                rangePlace.SetActive(false);
            }
        }
    }

    protected virtual void Attack()
    {

    }

    public virtual void LvlUp()
    {
        IsLvlUp = true;
        Money.Pay(LvlUpCost);
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
        var bullet = collider.GetComponent<Bullet>();
        var lava = collider.GetComponent<Lava>();
        var bang = collider.GetComponent<Bang>();
        if (!bullet && !lava && !bang)
        {
            objCountInPlace++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var bullet = collider.GetComponent<Bullet>();
        var lava = collider.GetComponent<Lava>();
        var bang = collider.GetComponent<Bang>();
        if (!bullet && !lava && !bang)
        {
            objCountInPlace--;
        }
    }

    protected void OnMouseDown()
    {
        if (IsBuilding)
        {
            rangePlace.SetActive(true);
            var newSetting = Instantiate(setting, transform.position - new Vector3 (0, 0.75f, 0) , Quaternion.identity);
            newSetting.SellButton.Tower = this;
            newSetting.LvlUpButton.Tower = this;
            newSetting.LvlUpButton.GetComponentInChildren<Text>().text = LvlUpCost.ToString();
            newSetting.SellButton.GetComponentInChildren<Text>().text = SellCost.ToString();
            if (IsLvlUp)
            {
                newSetting.LvlUpButton.gameObject.SetActive(false);
                newSetting.transform.position -= new Vector3(0.5f, 0);
            }
            onTrigger = true;
        }
    }
}
