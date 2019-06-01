using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    private int startCount = 100;

    private Text text;

    private static int count;

    public static readonly int GunTowerCost = 70;

    public static readonly int CannonTowerCost = 110;

    public static readonly int LavaTowerCost = 200;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        text.text = startCount.ToString();
        count = startCount;
    }

    private void Update()
    {
        text.text = count.ToString();
    }

    public static void BuyTower(int cost)
    {
        count -= cost;
    }

    public static void GetMoney(int _count)
    {
        count += _count;
    }

    public static bool EnoughMoney(int cost)
    {
        return count >= cost ? true : false;
    }
}
