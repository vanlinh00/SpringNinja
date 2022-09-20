using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsController : Singleton<ColumnsController>
{
    private float _minDistance = 1.948f;
    private Vector3 _posColumn1 = new Vector3(-0.06f, -4.99f, 0);

    [SerializeField] GameObject _allColumns;
    [SerializeField] float _speed = 3f;

    public bool IsTouchMiddleCol = false;
    public int _idColumn;
    GameObject _firstCol;
    public bool isColumnsReady = false;
   public IEnumerator WaitLoadColumns()
    {
        yield return new WaitForEndOfFrame();
        _firstCol = ObjectPooler._instance.SpawnFromPool("Column_0"+ _idColumn, _posColumn1, Quaternion.Euler(0, 0, 90));
        Column Col = _firstCol.GetComponent<Column>();
        Col.SetnableCollisionScore(false);

        yield return new WaitForSeconds(0.01f);
        Col.GetHeaderCol().GetComponent<HeaderCol>().isPlayerStanding = true;
        BornSecondCol();
        BornNewColumn(5); 
    }
    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {   
        if(PlayerController._instance.isPlayerMove/*&& !IsTouchMiddleCol*/)
        {
            _speed = PlayerController._instance.CalculerSpeedMove();
            transform.Translate(-Vector3.right * _speed * Time.deltaTime);
        }
       
    }
    void BornSecondCol()
    {
        Vector3 NewPosChild = new Vector3(_posColumn1.x + Random.RandomRange(3f, 6f), Random.RandomRange(-5, -3f), 0);
        GameObject newCol = ObjectPooler._instance.SpawnFromPool("Column_0" + _idColumn, NewPosChild, Quaternion.Euler(0, 0, 90));
        newCol.transform.parent =_allColumns.transform;
    }
    public void BornNewColumn(int AmountCol)
    {
        for(int i=0;i< AmountCol; i++)
        {
            Vector3 PosLastChild = _allColumns.transform.GetChild(_allColumns.transform.childCount - 1).gameObject.transform.position;
            Vector3 NewPosChild = new Vector3(PosLastChild.x + Random.RandomRange(_minDistance, 3f), Random.RandomRange(-5, -3f), 0);
            GameObject newColumn = ObjectPooler._instance.SpawnFromPool("Column_0" + _idColumn, NewPosChild, Quaternion.Euler(0, 0, 90));
            newColumn.transform.parent = _allColumns.transform;
        }
       
    }
    public void AddOldColumnToPool(int AmountCol)
    {
        List<GameObject> AllColumnPass = new List<GameObject>();
        for(int i=0;i<AmountCol;i++)
        {
            GameObject OldCol = _allColumns.transform.GetChild(i).gameObject;
            OldCol.GetComponent<Column>().ResetColumn();
            OldCol.SetActive(false);
            AllColumnPass.Add(OldCol);
            ObjectPooler._instance.AddElement("Column_0" + _idColumn, OldCol);
        }
        for(int i=0;i<AllColumnPass.Count;i++)
        {
            AllColumnPass[i].transform.parent = ObjectPooler._instance.transform;
        }
    }
    //  -0.05999994     1.2-> 2.35
    // x ?  x+ 2.22313  + -0.06 =2.35
    public Vector3 newPosAllColumns()
    {
        float A = Random.RandomRange(1.2f, 2.35f);
        float PosX = A - _allColumns.transform.GetChild(0).transform.localPosition.x + transform.position.x;
        return new Vector3(PosX, _allColumns.transform.position.y, 0);
    }
    public void MoveAllColumnToTarget()
    {
        StartCoroutine(WaitTimeMoveTarget());
    }
    IEnumerator WaitTimeMoveTarget()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Move(_allColumns.transform, newPosAllColumns(), 0.25f));
        yield return new WaitForSeconds(0.25f);
        _firstCol.transform.parent = _allColumns.transform;
        _firstCol.transform.SetSiblingIndex(0);
        isColumnsReady = true;
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
