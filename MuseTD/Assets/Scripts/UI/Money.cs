using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    private int startCount = 100;

    private Text text;

    public static int Count { get; set; }

    public static readonly int GunTowerCost = 70;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        text.text = startCount.ToString();
        Count = startCount;
    }

    private void Update()
    {
        text.text = Count.ToString();
    }
}
