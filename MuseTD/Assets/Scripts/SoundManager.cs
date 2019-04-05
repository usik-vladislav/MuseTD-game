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
    }

    private void Update()
    {
        if (IsBeat && BeatManager.IsBeatPlay)
        {
            beatSound.Play();
        }
    }
}
