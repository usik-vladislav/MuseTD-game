using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpButton : Button
{
    public Tower Tower { get; set; }

    private void OnMouseUp()
    {
        Tower.LvlUp();
    }
}
