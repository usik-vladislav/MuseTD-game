using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static List<Tower> towers;

    private void Awake()
    {
        towers = new List<Tower>();
    }

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
        var isGun = false;
        var isCannon = false;
        var isLava = false;

        for (int i = 0; i < towers.Count; i++)
        {
            if (towers[i] is LavaTower)
            {
                isLava = true;
            }
            if (towers[i].IsTarget)
            {
                if (towers[i] is GunTower)
                {
                    isGun = true;
                }
                if (towers[i] is CannonTower)
                {
                    isCannon = true;
                }
            }
        }

        SoundManager.IsGun = isGun;
        SoundManager.IsCannon = isCannon;
        SoundManager.IsLava = isLava;
    }
}
