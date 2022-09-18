using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] GameObject _backGroundDynamic;
    [SerializeField] GameObject _backGroundStatic;
    BackGroundDynamic _backGroundDynamicSc;
    int _idBg = 1;
    void Start()
    {
        _backGroundDynamicSc = _backGroundDynamic.GetComponent<BackGroundDynamic>();
        StartCoroutine(WaitForLoadData());
    }
    IEnumerator WaitForLoadData()
    {
        yield return new WaitForEndOfFrame();
        _backGroundDynamicSc.idBg = _idBg;
        _backGroundDynamicSc.BornNewMountain();
    }

}
