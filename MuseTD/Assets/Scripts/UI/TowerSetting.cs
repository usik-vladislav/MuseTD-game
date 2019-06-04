using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSetting : MonoBehaviour
{
    public LvlUpButton LvlUpButton;

    public SellButton SellButton;

    private bool mayClick;

    private void Start()
    {
        mayClick = false;
        Invoke("Set", 0.3f);
    }

    private void Set()
    {
        mayClick = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && mayClick)
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
