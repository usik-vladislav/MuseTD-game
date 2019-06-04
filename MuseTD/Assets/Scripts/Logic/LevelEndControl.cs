using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndControl : MonoBehaviour
{
    [SerializeField]
    private GameObject restartWindow;

    [SerializeField]
    private GameObject beatManager;

    [SerializeField]
    private GameObject winWindow;

    public static bool IsEnded { get; set; }

    private void Start()
    {
        IsEnded = false;
    }

    private void Update()
    {

        if (Lives.CountOfLives == 0)
        {
            IsEnded = true;
            Time.timeScale = 0;
            restartWindow.SetActive(true);
            beatManager.SetActive(false);
        }
        else if (IsEnded)
        {
            Time.timeScale = 0;
            winWindow.SetActive(true);
            beatManager.SetActive(false);
        }

    }
}
