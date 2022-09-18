using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDynamic : MonoBehaviour
{
    [SerializeField] GameObject _allmountains;
    [SerializeField] GameObject _allLeafs;
    [SerializeField] GameObject _allClouds;
    [SerializeField] float _speedMove;
    public int idBg=1;
   
    void Update()
    {
        if (PlayerController._instance.isPlayerMove)
        {
            _allClouds.transform.Translate(-Vector3.right * _speedMove  * Time.deltaTime);
            _allmountains.transform.Translate(-Vector3.right * _speedMove/2 * Time.deltaTime);
            _allLeafs.transform.Translate(-Vector3.right * _speedMove/3 * Time.deltaTime);
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
  public void BornNewMountain()
    {
        GameObject newMoutain = null;

       if(_allmountains.transform.childCount==0)
        {
          Vector3 NewPosChild = new Vector3(0, 0, 0); 
          newMoutain =   ObjectPooler._instance.SpawnFromPool("Mountain_0"+idBg, NewPosChild, Quaternion.Euler(0, 0, 90));
          newMoutain.transform.parent = _allmountains.transform;
          newMoutain.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            Vector3 PostLastChild = _allmountains.transform.GetChild(0).localPosition;
            newMoutain = ObjectPooler._instance.SpawnFromPool("Mountain_0" + idBg, PostLastChild, Quaternion.Euler(0, 0, 90));
            newMoutain.transform.parent = _allmountains.transform;
            Vector3 PostNewChild = new Vector3(PostLastChild.x + 27.84f, PostLastChild.y, 0);
            newMoutain.transform.localPosition = PostNewChild;
        }
    }
}
