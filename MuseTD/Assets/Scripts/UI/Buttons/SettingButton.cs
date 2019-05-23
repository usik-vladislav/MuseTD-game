using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : Button
{
    [SerializeField]
    private GameObject setting;

    private void OnMouseUp()
    {
        setting.SetActive(!setting.activeSelf);
    }
}
