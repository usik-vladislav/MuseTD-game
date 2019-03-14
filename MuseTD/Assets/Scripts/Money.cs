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

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        text.text = startCount.ToString();
        Count = startCount;
    }

    private void Update()
    {
        if (SongManager.IsBeatFull)
        {
            Count++;
        }
        text.text = Count.ToString();
    }
}
