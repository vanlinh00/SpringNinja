using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundStatic : Singleton<BackGroundStatic>
{
    public int IdBg;
   [SerializeField] GameObject _allwalls;
   [SerializeField] GameObject _allbackGroundS;
    protected override void Awake()
    {
        base.Awake();
    }
    public void BornNewBackGround()
    {
        GameObject NewBG = ObjectPooler._instance.SpawnFromPool("BackGround_0" + IdBg, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
        NewBG.transform.parent = _allbackGroundS.transform;
        NewBG.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void BornNewWalls()
    {
        GameObject NewBG = ObjectPooler._instance.SpawnFromPool("Wall_0" + IdBg, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        NewBG.transform.parent = _allwalls.transform;
        NewBG.transform.localPosition = new Vector3(0, 0, 0);
    }
}
