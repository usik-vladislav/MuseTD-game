using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startLives = 100;

    private Text text;

    private static int countOfLives;

    public static int CountOfLives
    {
        get
        {
            return countOfLives;
        }

        set
        {
            countOfLives = value < 0 ? 0 : value;
        }
    }

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
    }
}
