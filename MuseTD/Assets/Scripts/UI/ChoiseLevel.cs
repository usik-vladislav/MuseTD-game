using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiseLevel : MonoBehaviour
{
    private int numberLevel = -1;

    [SerializeField]
    private Image lvl_1_icon;

    [SerializeField]
    private Sprite lvl_1_Image;

    [SerializeField]
    private AudioSource musik;

    [SerializeField]
    private AudioClip lvl_1_musik;

    private Image bg;

    private void Awake()
    {
        foreach (var e in Global.NumberCompletedLevels)
        {
            PlayerPrefs.SetInt(e.ToString(), e);
        }
        bg = GetComponentInChildren<Image>();
        musik = GetComponent<AudioSource>();
        musik.volume = Global.Musik;
        lvl_1_icon.color = PlayerPrefs.HasKey("1") ? Color.white : lvl_1_icon.color;
    }

    public void ClickPlay()
    {
        if (numberLevel > 0)
        {
            SceneManager.LoadScene(numberLevel);
        }
    }

    public void ClickBack()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickLvl_1()
    {
        numberLevel = 1;
        bg.sprite = lvl_1_Image;
        musik.clip = lvl_1_musik;
        musik.Play(7);
    }

    public void ClickComingSoon()
    {
        numberLevel = -1;
        bg.sprite = null;
        musik.Stop();
        musik.clip = null;
    }
}
