using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{   
    bonus=0,
    button = 1,
    compressing=2,
    fall=3,
    jump=4,
    land=5,
    water=6,
}
public class SoundController : MonoBehaviour
{
    public static SoundController _instance;
    public AudioSource audioFx;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            _instance = this;
        }
        //DontDestroyOnLoad(this);
    }
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
        }
    }
    public void OnPlayAudio(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Audio/sfx/{soundType.ToString()}");
        audioFx.clip = audio;
        audioFx.Play();
       // audioFx.PlayOneShot(audio);

    }
}