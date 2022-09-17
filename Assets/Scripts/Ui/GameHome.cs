using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : Singleton<GameHome>
{
    [SerializeField] Button _playGameBtn;
    [SerializeField] Button _audioBtn;
    protected override void Awake()
    {
        base.Awake();
        _playGameBtn.onClick.AddListener(PlayGame);
        _audioBtn.onClick.AddListener(SetAudio);
    }
   public void PlayGame()
    {
        this.gameObject.SetActive(false);
        UiController._instance.EnableGamePlay();
        CamearaController._instance.MoveToTarget();

    }
    void SetAudio()
    {

    }
}
