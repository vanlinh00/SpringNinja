using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearaController : Singleton<CamearaController>
{
    [SerializeField] GameObject _player;
    private Vector3 _offset;
    private Vector3 _newtrans;

    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _offset.x = transform.position.x - _player.transform.position.x;
       // _offset.y = transform.position.y - _player.transform.position.y;
        _newtrans = transform.position;

    }
    void LateUpdate()
    {
        _newtrans.x = _player.transform.position.x + _offset.x;
        _newtrans.y = transform.position.y;
        transform.position = _newtrans;
    }
  public void MoveToTarget()
    {
       Vector3 Target = new Vector3(1.1f, transform.position.y, transform.position.z);
        StartCoroutine(Move(transform, Target, 1f));
    }
    public void SetCameraGamePlay()
    {
        Vector3 Target = new Vector3(1.1f, transform.position.y, transform.position.z);
        transform.position = Target;
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
