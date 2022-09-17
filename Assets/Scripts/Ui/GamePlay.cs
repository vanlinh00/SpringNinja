using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : Singleton<GamePlay>
{
    [SerializeField] Text _currentScore;
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
}
