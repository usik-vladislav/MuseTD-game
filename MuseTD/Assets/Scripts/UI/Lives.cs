using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startLives = 100;

    private Text text;

    public static int CountOfLives { get; set; }

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        text.text = startLives.ToString();
        CountOfLives = startLives;
    }

    private void Update()
    {
        text.text = CountOfLives.ToString();
    }
    public static void TakeDamage(int damage)
    {
        CountOfLives -= damage;
        if (CountOfLives <= 0)
        {

        }
    }
}
