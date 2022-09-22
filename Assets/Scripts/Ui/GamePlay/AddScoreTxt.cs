using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreTxt : MonoBehaviour
{
    [SerializeField] Text _textAddScore;
    void OnEnable()
    {
        _textAddScore.color = new Color32(0, 0, 0, 255);
        StartCoroutine(FadeColor(255));
    }
    IEnumerator FadeColor(byte FadeColor)
    {
        while (0 < FadeColor)
        {
            FadeColor -= 5;
            yield return new WaitForEndOfFrame();
            _textAddScore.color = new Color32(0, 0, 0, FadeColor);
        }
    }
}
