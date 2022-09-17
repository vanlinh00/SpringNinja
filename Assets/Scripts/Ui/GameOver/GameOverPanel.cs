using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text _currentScoreTxt;
    [SerializeField] Text _bestScoreTxt;
    private void OnEnable()
    {
        UpdateCurrentScore();
    }
    public void UpdateCurrentScore()
    {
        int CurrentScore = PlayerController._instance.GetCurrentScore();
        _currentScoreTxt.text = CurrentScore.ToString();
        UpdateBestScore(CurrentScore);
    }
    public void UpdateBestScore(int CurrentScore)
    {
        int BestScore = DataPlayer.getInforPlayer().bestScore;
        if (BestScore < CurrentScore)
        {
            BestScore = CurrentScore;
            DataPlayer.UpdateBestScore(BestScore);
        }
        _bestScoreTxt.text = BestScore.ToString();
    }
}
