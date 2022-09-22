using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] GameObject _collisionScore;
    [SerializeField] GameObject _headerCol;
    public Vector3 PosHeader()
    {
        return new Vector3(transform.position.x, transform.position.y + transform.lossyScale.x * 13.26f/2, 0);
    }
    public void SetnableHaderCol(bool value)
    {
        _headerCol.SetActive(value);
    }
    public void SetnableCollisionScore(bool value)
    {
        _collisionScore.SetActive(value);
    }
    public GameObject GetHeaderCol()
    {
        return _headerCol;
    }
    public void ResetColumn()
    {
        _collisionScore.SetActive(true);
        _headerCol.GetComponent<HeaderCol>().isPlayerStanding = false;

    }

}
