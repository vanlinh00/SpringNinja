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
        InforPlayer inforPlayer = DataPlayer.getInforPlayer();

        if (inforPlayer.idLoadGameAgain)
        {
            DataPlayer.UpdataLoadGameAgain(false);
            CamearaController._instance.SetCameraGamePlay();
            EnableGamePlay();
        }
        else
        {
            EnableGameHome();
        }
    }

    public void EnableGameHome()
    {
        _gameHome.SetActive(true);
        _gameOverPanel.SetActive(false);
        _gamePlay.SetActive(false);
    }

    public void EnableGamePlay()
    {
        PlayerController._instance.isOnGame = true;
        ColumnsController._instance.MoveAllColumnToTarget();
        _gameHome.SetActive(false);
        _gameOverPanel.SetActive(false);
        _gamePlay.SetActive(true);
    }

    public void EnableGameOver()
    {
        _gamePlay.SetActive(false);
        _gameOverPanel.SetActive(true);
        GameOver._instance.In();
    }


}
