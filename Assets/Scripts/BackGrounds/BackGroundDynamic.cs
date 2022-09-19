using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDynamic : Singleton<BackGroundDynamic>
{
    [SerializeField] GameObject _allmountains;
    [SerializeField] GameObject _allLeafs;
    [SerializeField] GameObject _allClouds;
    [SerializeField] GameObject _notice;
    [SerializeField] float _speedMove;
    public int idBg=1;

    protected override void Awake()
    {
        base.Awake();
    }
    void Update()
    {
        if (PlayerController._instance.isPlayerMove)
        {
            _allClouds.transform.Translate(-Vector3.right * _speedMove  * Time.deltaTime);
            _notice.transform.Translate(-Vector3.right * _speedMove * Time.deltaTime);
            _allmountains.transform.Translate(-Vector3.right * _speedMove/2 * Time.deltaTime);
            _allLeafs.transform.Translate(-Vector3.right * _speedMove/3 * Time.deltaTime);
        }
        else
        {
           _allClouds.transform.Translate(-Vector3.right * _speedMove / 10 * Time.deltaTime);
        }
           
    }
  public void BornNewCloud(int AmountColPass,int AmountScore)
    {
        GameObject newCloud = null;
        Vector3 PosLastChildCount;
        int CountChild = _allClouds.transform.childCount;

        if (CountChild == 0)
        {
            PosLastChildCount = new Vector3(0, 0, 0);
        }
        else
        {

            PosLastChildCount= _allClouds.transform.GetChild(CountChild-1).transform.localPosition;
        }

        if(AmountColPass==0|| AmountColPass%2==0)
        {
            for (int i = 0; i < 5; i++)
            {
                float posY = Random.RandomRange(0, -2.25f);
                Vector3 NewPosChild = new Vector3(0, 0, 0);
                newCloud = ObjectPooler._instance.SpawnFromPool("Cloud_0" + idBg, NewPosChild, Quaternion.Euler(0, 0, 0));
                newCloud.transform.parent = _allClouds.transform;
                newCloud.transform.localPosition = new Vector3(i * 2.45f + PosLastChildCount.x, posY, 0);
            }
        }
    }
  public void BornNewMountain()
    {
        GameObject newMoutain = null;
        int CountChild = _allmountains.transform.childCount;
       if (CountChild == 0)
        {
          Vector3 NewPosChild = new Vector3(0, 0, 0); 
          newMoutain =   ObjectPooler._instance.SpawnFromPool("Mountain_0"+idBg, NewPosChild, Quaternion.Euler(0, 0, 90));
          newMoutain.transform.parent = _allmountains.transform;
          newMoutain.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            Vector3 PosPlayer = PlayerController._instance.gameObject.transform.position;
            GameObject LastChild = _allmountains.transform.GetChild(CountChild - 1).gameObject;
            Vector3 PostLastChild = LastChild.transform.localPosition;

            if (Vector3.Distance(PosPlayer, LastChild.transform.position)<7f)
            {
                float Distance2Mountain = LastChild.GetComponent<SpriteRenderer>().size.y / 2;
                newMoutain = ObjectPooler._instance.SpawnFromPool("Mountain_0" + idBg, PostLastChild, Quaternion.Euler(0, 0, 90));
                newMoutain.transform.parent = _allmountains.transform;
                Vector3 PostNewChild = new Vector3(PostLastChild.x+ Distance2Mountain- 0.0527f, PostLastChild.y, 0);
                newMoutain.transform.localPosition = PostNewChild;
            }else
            {
                return;
            }

        }
    }


}
