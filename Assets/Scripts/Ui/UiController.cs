using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : Singleton<UiController>
{
    [SerializeField] GameObject _gameHome;
    [SerializeField] GameObject _gamePlay;
    [SerializeField] GameObject _gameOverPanel;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        InforPlayer inforPlayer = DataPlayer.GetInforPlayer();
        if (inforPlayer.isLoadGameAgain)
        {
            StartCoroutine(WaitLoadGameAgain());
            LoadGameAgain();
           // EnableGamePlay();
        }
        else
        {
            EnableGameHome();
        }
    }
    void LoadGameAgain()
    {
        CamearaController._instance.SetCameraGamePlay();
        int StateAudio;
        if (DataPlayer.GetInforPlayer().isOnAudio)
        {
            StateAudio = 1;
        }
        else
        {
            StateAudio = 2;
        }
        AudioManager._instance.ChangeStateAudio(StateAudio);
        PlayerController._instance.isOnGame = true;
        ColumnsController._instance.MoveAllColumnToTarget();
        _gameHome.SetActive(false);
        _gamePlay.SetActive(true);
        _gamePlay.GetComponent<GamePlay>().In();
        _gameOverPanel.SetActive(false);
    }
    IEnumerator WaitLoadGameAgain()
    {
        yield return new WaitForSeconds(0.2f);
        DataPlayer.UpdataLoadGameAgain(false);
    }

    public void EnableGameHome()
    {
        _gameHome.SetActive(true);
        _gameHome.GetComponent<GameHome>().In();
        _gameOverPanel.SetActive(false);
        _gamePlay.SetActive(false);
    }
    public void EnableGamePlay()
    {
        PlayerController._instance.isOnGame = true;
        ColumnsController._instance.MoveAllColumnToTarget();
        StartCoroutine(FadeEnableGamePlay());
        _gameOverPanel.SetActive(false);
     
    }
    IEnumerator FadeEnableGamePlay()
    {
        _gameHome.GetComponent<GameHome>().Out();
        yield return new WaitForSeconds(0.2f);
        _gameHome.SetActive(false);
        _gamePlay.SetActive(true);
        _gamePlay.GetComponent<GamePlay>().In();     
    }

    public void EnableGameOver()
    {
        _gamePlay.SetActive(false);
        _gameOverPanel.SetActive(true);
        GameOver._instance.In();
    }


}
