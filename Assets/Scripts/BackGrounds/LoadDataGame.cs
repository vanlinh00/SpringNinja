using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataGame : MonoBehaviour
{
    [SerializeField] GameObject _backGroundDynamic;
    [SerializeField] GameObject _backGroundStatic;

    BackGroundDynamic _backGroundDynamicSc;
    BackGroundStatic _backGroundStaticSc;

    [SerializeField] ColumnsController _columnsController;
    [SerializeField] WaweManager _waweManager;

    int _idBg;
    void Start()
    {
        _idBg = 1; /*Random.RandomRange(1, 4);*/
       _backGroundDynamicSc = _backGroundDynamic.GetComponent<BackGroundDynamic>();
        _backGroundStaticSc = _backGroundStatic.GetComponent<BackGroundStatic>();
        StartCoroutine(WaitForLoadData());
    }
    IEnumerator WaitForLoadData()
    {
        yield return new WaitForEndOfFrame();
        //Load BackGround Static
        _backGroundStaticSc.IdBg = _idBg;
        _backGroundStaticSc.BornNewBackGround();
        _backGroundStaticSc.BornNewWalls();

        //Load Wawe 
        _waweManager.IdBg = _idBg;
        _waweManager.WaitLoadAllWawe();

        // Load BackGround
        _backGroundDynamicSc.idBg = _idBg;
        _backGroundDynamicSc.BornNewMountain();

        //_backGroundDynamicSc.BornNewCloud(0);

        // load columns 
        _columnsController._idColumn = _idBg;
        StartCoroutine(_columnsController.WaitLoadColumns());
    }

}
