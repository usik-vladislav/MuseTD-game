using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiseLevel : MonoBehaviour
{
    private int numberLevel = -1;

    [SerializeField]
    private Sprite lvl_1_Image;

    private Image bg;

    private void Start()
    {
        bg = GetComponentInChildren<Image>();
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
    }

    public void ClickComingSoon()
    {
        numberLevel = -1;
        bg.sprite = null;
    }
}
