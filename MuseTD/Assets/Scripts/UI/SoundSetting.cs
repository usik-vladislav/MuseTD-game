using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();

        slider.value = Global.Sound;
    }

    private void SetSoundVolume(float value)
    {
        Global.Sound = value;
    }
}
