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
        DataPlayer.UpdataLoadGameAgain(true);
        SceneManager.LoadScene(0);
    }
    void GoHomeUi()
    {
        SceneManager.LoadScene(0);
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
