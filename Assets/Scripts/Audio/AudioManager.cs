using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void ChangeStateAudio(int CountOnOfAudio)
    {
        int NumberAudio = 1;
        if (CountOnOfAudio % 2 == 0)
        {
            NumberAudio = 2;
            SoundController._instance.audioFx.volume = 0;
            SoundBackGround._instance.audioFx.volume = 0;
            DataPlayer.ChangeStateAudio(false);
        }
        else
        {
            SoundBackGround._instance.audioFx.volume = 1;
            SoundController._instance.audioFx.volume = 1;
            NumberAudio = 1;
            DataPlayer.ChangeStateAudio(true);
        }
    }
}
