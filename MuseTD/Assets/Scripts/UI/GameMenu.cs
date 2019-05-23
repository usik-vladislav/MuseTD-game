using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void ClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickExit()
    {
        SceneManager.LoadScene(0);
    }
}
