using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearaController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private Vector3 _offset;
    private Vector3 _newtrans;

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
}
