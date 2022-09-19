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
            if (PlayerController._instance.currentTimeHold <= (PlayerController._instance.GetTimeHoldMax() / 2f))
            {
                _speed = 1.5f;
            }
            else if (PlayerController._instance.currentTimeHold <= (PlayerController._instance.GetTimeHoldMax() * 3 / 4))
            {
                _speed = 2.2f;
            }
            else
            {
                _speed = 3.2f;
            }
            transform.Translate(-Vector3.right * _speed * Time.deltaTime);
        }

    }
}
