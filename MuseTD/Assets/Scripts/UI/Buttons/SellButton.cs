using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : Button
{
    public Tower Tower { get; set; }

    private void OnMouseUp()
    {
        Tower.IsSelled = true;
    }
}
