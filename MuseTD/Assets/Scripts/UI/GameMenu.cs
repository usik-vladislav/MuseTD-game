using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    private void ClickRestart()
    {
        BeatManager.IsBeatFull = false;
        BeatManager.IsBeatD4 = false;
        SceneManager.LoadScene(1);
    }

    private void Win()
    {
        Global.NumberCompletedLevels.Add(1);
        ClickExit();
    }

    private void ClickExit()
    {
        SceneManager.LoadScene(2);
    }
}
