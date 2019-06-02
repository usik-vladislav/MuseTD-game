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

    [SerializeField]
    private AudioSource miniGunSound;

    public static bool IsGun = false;

    public static bool IsCannon = false;

    public static bool IsLava = false;

    public static bool IsMiniGun = false;

    public static bool IsUpCannon = false;

    private bool isUpBall = false;

    private bool isBall = false;

    [SerializeField]
    private float gunVolume;

    [SerializeField]
    private float cannonShootVolume;

    [SerializeField]
    private float cannonBangVolume;

    [SerializeField]
    private float lavaVolume;

    [SerializeField]
    private float miniGunVolume;

    private void Update()
    {
        gunSound.volume = gunVolume * Global.Sound;
        cannonShootSound.volume = cannonShootVolume * Global.Sound;
        cannonBangSound.volume = cannonBangVolume * Global.Sound;
        lavaSound.volume = lavaVolume * Global.Sound;
        miniGunSound.volume = miniGunVolume * Global.Sound;

        if (BeatManager.IsBeatD4 && BeatManager.CountBeatD4 % 2 == 0)
        {
            if (IsMiniGun)
            {
                miniGunSound.Play();
            }

            if (isUpBall)
            {
                cannonBangSound.Play();
                isUpBall = false;
            }
        }

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
                    if (IsUpCannon)
                    {
                        isUpBall = true;
                    }
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
