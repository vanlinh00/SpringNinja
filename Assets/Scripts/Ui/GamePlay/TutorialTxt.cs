using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTxt : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    public void Out()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float t = 1;
        while (_canvasGroup.alpha >0)
        {
            yield return new WaitForEndOfFrame();
            _canvasGroup.alpha = t;
            t -= Time.deltaTime * 1.7f;
        }
    }
}
