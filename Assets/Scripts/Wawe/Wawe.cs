using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawe : MonoBehaviour
{
    [SerializeField] float _speedMove;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Vector3 _currentPos;
    private void Start()
    {
        StartCoroutine(Undulating());
    }
    IEnumerator Undulating()
    {
        while(true)
        {
            StartCoroutine(Move(transform,_targetPos, _speedMove));
            yield return new WaitForSeconds(_speedMove);
            StartCoroutine(Move(transform, _currentPos, _speedMove));
            yield return new WaitForSeconds(_speedMove);
        }    
    }

    IEnumerator Move(Transform CurrentTransform, Vector3 Target, float TotalTime)
    {
        var passed = 0f;
        var init = CurrentTransform.transform.position;
        while (passed < TotalTime)
        {
            passed += Time.deltaTime;
            var normalized = passed / TotalTime;
            var current = Vector3.Lerp(init, Target, normalized);
            CurrentTransform.position = current;
            yield return null;
        }
    }

}
