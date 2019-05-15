using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerButton : MonoBehaviour
{
    private GunTower tower;

    private void Awake()
    {
        tower = Resources.Load<GunTower>("GunTower");
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    private void OnMouseUp()
    {
        if (Money.EnoughMoney(Money.GunTowerCost))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            var newTower = Instantiate<GunTower>(tower, mousePos, Quaternion.identity);
            newTower.IsBuilding = false;
        }
    }
}
