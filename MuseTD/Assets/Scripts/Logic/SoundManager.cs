using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource beatSound;

    public static bool IsBeat = false; 

    private void Awake()
    {
        beatSound = GetComponent<AudioSource>();
        beatSound.volume = Global.Sound;
    }

    private void Update()
    {
        beatSound.volume = Global.Sound;
        if (IsBeat && BeatManager.IsBeatPlay)
        {
            beatSound.Play();
        }
    }
}
