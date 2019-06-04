﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusikSetting : MonoBehaviour
{
    private Slider slider;


    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();

        slider.value = Global.Musik;
    }


    private void SetMusikVolume(float value)
    {
        Global.Musik = value;
    }

}
