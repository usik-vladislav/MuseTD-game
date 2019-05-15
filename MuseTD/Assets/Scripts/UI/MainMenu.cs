using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Setting;


    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenOptions()
    {
        Setting.SetActive(!Setting.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
