using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : Singleton<GameHome>
{
    [SerializeField] Button _playGameBtn;
    [SerializeField] Button _audioBtn;

    [SerializeField] GameObject _audio;
    private int _countOnOfAudio;
    [SerializeField] CanvasGroup _canvasGroup;

    protected override void Awake()
    {
        base.Awake();
        _playGameBtn.onClick.AddListener(PlayGame);
        _audioBtn.onClick.AddListener(SetAudio);
    }
    private void OnEnable()
    {
        StartCoroutine(WaitTimeEnableAudio());
    }
    IEnumerator WaitTimeEnableAudio()
    {
        yield return new WaitForEndOfFrame();

        if (DataPlayer.GetInforPlayer().isOnAudio)
        {
            _countOnOfAudio = 1;
        }
        else
        {
            _countOnOfAudio = 2;
        }
        AudioManager._instance.ChangeStateAudio(_countOnOfAudio);
        ChangeSpriteAudio(_countOnOfAudio);

    }
    public void PlayGame()
    {
        SoundController._instance.OnPlayAudio(SoundType.button);
        UiController._instance.EnableGamePlay();
        CamearaController._instance.MoveToTarget();
        Out();
    }
    void SetAudio()
    {
        _countOnOfAudio++;
        SoundController._instance.OnPlayAudio(SoundType.button);
        AudioManager._instance.ChangeStateAudio(_countOnOfAudio);
        ChangeSpriteAudio(_countOnOfAudio);
    }
    void ChangeSpriteAudio(int CountOnOfAudio)
    {
        int NumberAudio = (CountOnOfAudio % 2 == 0) ? 2: 1;
        GameObject NewStateAudio = ObjectPooler._instance.SpawnFromPool("Audio" + NumberAudio, new Vector3(0, 0, 0), Quaternion.identity); /*Instantiate(Resources.Load("Image/Audio/"+ NumberAudio, typeof(GameObject))) as GameObject;*/
        NewStateAudio.SetActive(false);
        Sprite SpriteAudio = NewStateAudio.GetComponent<SpriteRenderer>().sprite;
        _audio.gameObject.GetComponent<Image>().sprite = SpriteAudio;
        ObjectPooler._instance.AddElement("Audio" + NumberAudio, NewStateAudio);
    }

    public void Out()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float t = 1;
        while (_canvasGroup.alpha >= 0)
        {
            yield return new WaitForEndOfFrame();
            _canvasGroup.alpha = t;
            t -= Time.deltaTime * 2f;
        }
    }
    public void In()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float t = 0;
        while (_canvasGroup.alpha < 1)
        {
            yield return new WaitForEndOfFrame();
            _canvasGroup.alpha = t;
            t += Time.deltaTime * 1.7f;
        }
    }
}
