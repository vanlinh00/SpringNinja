using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDynamic : MonoBehaviour
{
    [SerializeField] GameObject _allmountains;
    [SerializeField] GameObject _allLeaf;
    [SerializeField] GameObject _allClouds;
    [SerializeField] float _speedMove;
   
    void Update()
    {
        if (PlayerController._instance.isPlayerMove)
        {
            _allClouds.transform.Translate(-Vector3.right * _speedMove  * Time.deltaTime);
            _allmountains.transform.Translate(-Vector3.right * _speedMove/2 * Time.deltaTime);
            _allLeaf.transform.Translate(-Vector3.right * _speedMove/3 * Time.deltaTime);
        }
        else
        {
           _allClouds.transform.Translate(-Vector3.right * _speedMove / 10 * Time.deltaTime);
        }
           
    }
  public void BornNewCloud()
    {
        Vector3 PosLastChildCount = _allClouds.transform.GetChild(0).position;

    }
}
