using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : Singleton<GamePlay>
{
    [SerializeField] Text _currentScore;
    [SerializeField] Text _bonusScoreTxt;
    [SerializeField] TutorialTxt _tutorialTxt;
    [SerializeField] CanvasGroup _canvasGroup;
    void Start()
    {
        _currentScore.text = 0.ToString();
    }
    protected override void Awake()
    {
        base.Awake();

    }
    public void UpdateCurretScore()
    {
        _currentScore.text = PlayerController._instance.GetCurrentScore().ToString();
    }
    public void EnableAddScoreTxt(int AmountScore)
    {
        _bonusScoreTxt.text ="+"+ AmountScore.ToString();
        _bonusScoreTxt.gameObject.SetActive(true);
    }
    public void DisableAddScoreTxt()
    {
        _bonusScoreTxt.gameObject.SetActive(false);
    }
    public void DisableTutorial()
    {
        _tutorialTxt.Out();
    }
   public IEnumerator WaitTimeDisableAddScoreTxt(int AmountScore)
    {
        SoundController._instance.OnPlayAudio(SoundType.bonus);
        EnableAddScoreTxt(AmountScore);
        yield return new WaitForSeconds(0.5f);
        DisableAddScoreTxt();
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
