using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : Button
{

    [SerializeField]
    private GameObject beatManager;

    private void OnMouseUp()
    {
        if (LevelEndControl.IsEnded)
        {
            return;
        }
        Time.timeScale = 1;
        beatManager.SetActive(true);
        gameObject.SetActive(false);
    }
}
