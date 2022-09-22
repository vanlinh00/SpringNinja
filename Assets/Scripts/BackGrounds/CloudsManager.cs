using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    public int idBg;
   
    public void BornNewCloud()
    {
        AddCloudToPooler();

        Vector3 PosLastChild;

        int CountChild = transform.childCount;

        if (CountChild == 0)
        {
            PosLastChild = new Vector3(-1.73f, 4.28f, 0);
        }
        else
        {
            PosLastChild = transform.GetChild(transform.childCount - 1).gameObject.transform.position;
        }
        if(CountChild<9)
        {
            for (int i = 0; i < 3; i++)
            {
                if (transform.childCount != 0)
                {
                    PosLastChild = transform.GetChild(transform.childCount - 1).gameObject.transform.position;
                }

                Vector3 NewPosChild = new Vector3(PosLastChild.x + Random.RandomRange(2.2f, 3f), Random.RandomRange(2f, 4.28f), 0);
                GameObject newCloud = ObjectPooler._instance.SpawnFromPool("Cloud_0" + idBg, NewPosChild, Quaternion.Euler(0, 0, 0));
                newCloud.transform.parent = transform;
                float NewScale = Random.RandomRange(0.25f, 0.5f);
                newCloud.transform.localScale = new Vector3(NewScale, NewScale, NewScale);
            }
        }

    }
    public void AddCloudToPooler()
    {
        List<GameObject> ListClouds = new List<GameObject>();
        if (transform.childCount >= 18)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject OldCloud = transform.GetChild(i).gameObject;
                OldCloud.SetActive(false);
                ObjectPooler._instance.AddElement("Cloud_0" + idBg, transform.GetChild(i).gameObject);
                ListClouds.Add(OldCloud);
            }
            for(int i=0;i<3;i++)
            {
                ListClouds[i].transform.parent = ObjectPooler._instance.transform;
            }
        }

    }

}
