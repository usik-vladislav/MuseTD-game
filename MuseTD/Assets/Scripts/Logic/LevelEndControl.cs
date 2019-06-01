using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndControl : MonoBehaviour
{
    [SerializeField]
    private GameObject restartWindow;

    [SerializeField]
    private GameObject winWindow;

    public static bool IsEnded { get; set; }

    private void Start()
    {
        IsEnded = false;
    }

    public void Update()
    {

        if (Lives.CountOfLives == 0)
        {
            IsEnded = true;
            Time.timeScale = 0;
            restartWindow.SetActive(true);
        }
        else if (IsEnded)
        {
            Time.timeScale = 0;
            winWindow.SetActive(true);
        }

    }
}
