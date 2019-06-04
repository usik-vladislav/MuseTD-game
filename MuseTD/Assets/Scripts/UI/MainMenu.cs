using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Setting;


    private void Play()
    {
        SceneManager.LoadScene(2);
    }

    private void OpenOptions()
    {
        Setting.SetActive(!Setting.activeSelf);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
