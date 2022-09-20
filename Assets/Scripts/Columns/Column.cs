using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] GameObject CollisionScore;
    [SerializeField] GameObject HeaderCol;
   
    public Vector3 PosHeader()
    {
        return new Vector3(transform.position.x, transform.position.y + transform.lossyScale.x * 13.26f/2, 0);
    }
    public void SetnableHaderCol(bool value)
    {
        HeaderCol.SetActive(value);
    }
    public void SetnableCollisionScore(bool value)
    {
        CollisionScore.SetActive(value);
    }
    public GameObject GetHeaderCol()
    {
        return HeaderCol;
    }

}
