using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweManager : Singleton<WaweManager>
{
    [SerializeField] GameObject _allWaweGr01;
    [SerializeField] GameObject _allWaweGr02;
    [SerializeField] GameObject _allWaweGr03;
    [SerializeField] float _speed = 3f;
    public int IdBg;

    protected override void Awake()
    {
        base.Awake();
    }
    public void WaitLoadAllWawe()
    {
        BornAllWawe();
    }
    public void BornAllWawe()
    {
        BornNewWawe(_allWaweGr01, 1, 7.54f);
        BornNewWawe(_allWaweGr02, 2, 8.768f);
        BornNewWawe(_allWaweGr03, 3, 6.33f);
    }
    public void BornNewWawe(GameObject AllWaweGr,int NumberWawe,float Distance2Wawe)
    {
        GameObject newMoutain = null;
       // float Distance2Wawe = 7.54f;
        int CountChild = AllWaweGr.transform.childCount;
        if (CountChild == 0)
        {
            Vector3 NewPosChild = new Vector3(0, 0, 0);

            for(int i=0;i<3;i++)
            {
                newMoutain = ObjectPooler._instance.SpawnFromPool("Wawe_"+ NumberWawe + IdBg, NewPosChild, Quaternion.Euler(0, 0, 0));
                newMoutain.transform.parent = AllWaweGr.transform;
                newMoutain.transform.localPosition = new Vector3(i* Distance2Wawe, 0, 0);
            }

        }
        else
        {
            Vector3 PosPlayer = PlayerController._instance.gameObject.transform.position;
            GameObject LastChild = AllWaweGr.transform.GetChild(CountChild - 1).gameObject;
            Vector3 PostLastChild = LastChild.transform.localPosition;

            //if (Vector3.Distance(PosPlayer, LastChild.transform.position) < 20f)
            //{
                newMoutain = ObjectPooler._instance.SpawnFromPool("Wawe_"+ NumberWawe + IdBg, PostLastChild, Quaternion.Euler(0, 0, 0));
                newMoutain.transform.parent = AllWaweGr.transform;
                Vector3 PostNewChild = new Vector3(PostLastChild.x + Distance2Wawe, PostLastChild.y, 0);
                newMoutain.transform.localPosition = PostNewChild;
            //}
            //else
            //{
            //    return;
            //}

        }
    }
}
