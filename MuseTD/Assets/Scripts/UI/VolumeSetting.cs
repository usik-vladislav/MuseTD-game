using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    public void SetMusikVolume(float value)
    {
        Global.Musik = value;
    }

    public void SetSoundVolume(float value)
    {
        Global.Sound = value;
    }
}
