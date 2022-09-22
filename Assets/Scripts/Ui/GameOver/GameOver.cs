using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : Singleton<GameOver>
{
    [SerializeField] Button _restartBtn;
    [SerializeField] Button _homeBtn;
    [SerializeField] CanvasGroup _canvasGroup;
    protected override void Awake()
    {
        base.Awake();
        _restartBtn.onClick.AddListener(RestartGame);
        _homeBtn.onClick.AddListener(GoHomeUi);
    }
    void RestartGame()
    {
        SoundController._instance.OnPlayAudio(SoundType.button);
        DataPlayer.UpdataLoadGameAgain(true);
        StartCoroutine(Out());
    }
    void GoHomeUi()
    {
        SoundController._instance.OnPlayAudio(SoundType.button);
        StartCoroutine(Out());
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
    IEnumerator Out()
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
        //yield return new WaitForSeconds(0.5655f);
 
    }
    IEnumerator FadeOut()
    {
        float t = 1;
        while (_canvasGroup.alpha >=0)
        {
            yield return new WaitForEndOfFrame();
            _canvasGroup.alpha = t;
            t -= Time.deltaTime * 1.7f;
        }
      
    }
}
