using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlayer : MonoBehaviour
{
    [SerializeField] GameObject _eyes;
    [SerializeField] GameObject _hand;
    private float _smoothRotation = 2.5f;

    IEnumerator FadeRotation(float currentDegree, float Degree)
    {
        float t = currentDegree;
        _smoothRotation = (currentDegree == -90f) ? 5f * _smoothRotation : 1.5f * _smoothRotation;
        while (t >= Degree)
        {
            yield return new WaitForEndOfFrame();
            t -= _smoothRotation;
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (t > Degree) ? t : Degree);
            transform.rotation = target;
        }
    }
}
