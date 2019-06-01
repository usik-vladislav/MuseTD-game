using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource gunSound;

    [SerializeField]
    private AudioSource cannonShootSound;

    [SerializeField]
    private AudioSource cannonBangSound;

    [SerializeField]
    private AudioSource lavaSound;

    public static bool IsGun = false;

    public static bool IsCannon = false;

    public static bool IsLava = false;

    private bool isBall = false;

    [SerializeField]
    private float gunVolume;

    [SerializeField]
    private float cannonShootVolume;

    [SerializeField]
    private float cannonBangVolume;

    [SerializeField]
    private float lavaVolume;

    private void Update()
    {
        gunSound.volume = gunVolume * Global.Sound;
        cannonShootSound.volume = cannonShootVolume * Global.Sound;
        cannonBangSound.volume = cannonBangVolume * Global.Sound;
        lavaSound.volume = lavaVolume * Global.Sound;

        if (BeatManager.IsBeatFull && !LevelEndControl.IsEnded)
        {
            if (IsGun)
            {
                gunSound.Play();
            }
            if (IsCannon)
            {
                if (BeatManager.CountBeat % 2 == 0)
                {
                    cannonShootSound.Play();
                    isBall = true;
                }
                else if (isBall)
                {
                    cannonBangSound.Play();
                    isBall = false;
                }
            }
            if (IsLava)
            {
                if (BeatManager.CountBeat % 4 == 0)
                {
                    lavaSound.Play();
                }
                if (BeatManager.CountBeat % 4 == 3)
                {
                    lavaSound.Stop();
                }
            }
        }
    }
}
