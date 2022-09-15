using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] Button _restartBnt;
    private void Awake()
    {
        _restartBnt.onClick.AddListener(RestartGame);
    }
    void Start()
    {
        
    }
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
