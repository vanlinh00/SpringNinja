using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWawe : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    void Update()
    {
        if (PlayerController._instance.isPlayerMove/*&& !IsTouchMiddleCol*/)
        {
            _speed = PlayerController._instance.CalculerSpeedMove();
            transform.Translate(-Vector3.right * _speed * Time.deltaTime);
        }

    }
}
