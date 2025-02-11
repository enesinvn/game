using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour


{
    public AudioSource[] soundEffects;
    public static AudioManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfx(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }

    internal void StopSfx(int v)
    {
        throw new NotImplementedException();
    }
}
