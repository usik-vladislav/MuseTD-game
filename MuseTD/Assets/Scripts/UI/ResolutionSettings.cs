using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResolutionSettings : MonoBehaviour
{
    public Dropdown dropdown;

    public Toggle toggle;

    private Resolution[] resolutions;

    public void Awake()
    {
        resolutions = Screen.resolutions;

        Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);

        toggle.isOn = Screen.fullScreen;

        var res = resolutions.Select(x => x.width.ToString() + "x" + x.height.ToString());
        dropdown.AddOptions(res.ToList());
        dropdown.value = res.Count() - 1;
    }

    public void SetResolution()
    {
        Screen.SetResolution(resolutions[dropdown.value].width, resolutions[dropdown.value].height, Screen.fullScreen);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
