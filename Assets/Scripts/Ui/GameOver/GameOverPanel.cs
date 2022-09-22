using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text _currentScoreTxt;
    [SerializeField] Text _bestScoreTxt;
    [SerializeField] GameObject _rewardImg;
    private void OnEnable()
    {
        UpdateCurrentScore();
    }
    public void UpdateCurrentScore()
    {
        int CurrentScore = PlayerController._instance.GetCurrentScore();
        _currentScoreTxt.text = CurrentScore.ToString();
        UpdateBestScore(CurrentScore);
        UpdateReward(CurrentScore);
    }
    public void UpdateBestScore(int CurrentScore)
    {
        int BestScore = DataPlayer.GetInforPlayer().bestScore;
        if (BestScore < CurrentScore)
        {
            BestScore = CurrentScore;
            DataPlayer.UpdateBestScore(BestScore);
        }
        _bestScoreTxt.text = BestScore.ToString();
    }
    public void UpdateReward(int CurrentScore)
    {
        int idReward = 1;
        if(CurrentScore<5)
        {
            idReward = 1;
        }else if(CurrentScore<10)
        {
            idReward = 2;
        }else if(CurrentScore<15)
        {
            idReward = 3;
        }else if(CurrentScore<20)
        {
            idReward = 4;
        }
        else
        {
            idReward = 5;
        }
        GameObject NewRewar = Instantiate(Resources.Load("Reward/Reward" + idReward, typeof(GameObject))) as GameObject;
        NewRewar.transform.SetParent(_rewardImg.transform);
        RectTransform newRectReward = NewRewar.GetComponent<RectTransform>();
        newRectReward.anchoredPosition = new Vector2(0, 68);
        newRectReward.localScale = new Vector3(1, 1, 1);
    }
}
