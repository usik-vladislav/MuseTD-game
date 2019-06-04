using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void ClickRestart()
    {
        BeatManager.IsBeatFull = false;
        BeatManager.IsBeatD4 = false;
        SceneManager.LoadScene(1);
    }

    public void Win()
    {
        Global.NumberCompletedLevels.Add(1);
        ClickExit();
    }

    public void ClickExit()
    {
        SceneManager.LoadScene(2);
    }
}
