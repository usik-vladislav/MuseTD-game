using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTower1 : MonoBehaviour
{
    private Tower tower;

    private void Awake()
    {
        tower = Resources.Load<Tower>("Tower");
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseDown()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var newTower = Instantiate<Tower>(tower, mousePos, Quaternion.identity);
        newTower.IsBuilding = false;
    }
}
