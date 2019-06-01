using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : Button
{
    [SerializeField]
    private GameObject setting;

    private void OnMouseUp()
    {
        if (LevelEndControl.IsEnded)
        {
            return;
        }
        setting.SetActive(!setting.activeSelf);
    }
}
