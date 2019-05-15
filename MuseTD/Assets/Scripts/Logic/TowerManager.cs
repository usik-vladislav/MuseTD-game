using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static List<Tower> towers = new List<Tower>();

    public static void AddTower(Tower tower)
    {
        towers.Add(tower);
    }

    public static void RemoveTower(Tower tower)
    {
        towers.Remove(tower);
    }

    public void Update()
    {
        var isBeat = false;
        for (int i = 0; i < towers.Count; i++)
        {
            if (towers[i].Target)
            {
                if (towers[i] is GunTower)
                {
                    SoundManager.IsBeat = true;
                    isBeat = true;
                }
            }
        }
        if (!isBeat)
        {
            SoundManager.IsBeat = false;
        }
    }
}
