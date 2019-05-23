using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    private Slider slider;

    public void Awake()
    {
        slider = GetComponentInChildren<Slider>();

        slider.value = Global.Sound;
    }

    public void SetSoundVolume(float value)
    {
        Global.Sound = value;
    }
}
