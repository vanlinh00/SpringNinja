using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public void FlyDown()
    {
        _animator.SetBool("FlyDown", true);
    }
    public void FlyUp()
    {
        _animator.SetBool("FlyDown", false);
        _animator.SetBool("FlyUp", true);
    }
    public void Idle()
    {
        _animator.SetBool("FlyDown", false);
        _animator.SetBool("FlyUp", false);
    }
    public void FilpRight()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    public void FilpLeft()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    public void MoveDown(Vector3 Target)
    {
        FlyDown();
        MoveToTarget(Target);
    }
    public void MoveUp(Vector3 Target)
    {
        FlyUp();
        MoveToTarget(Target);
    }
    public void MoveToTarget(Vector3 Target)
    {
        StartCoroutine(Move(transform, Target, 2f));
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
