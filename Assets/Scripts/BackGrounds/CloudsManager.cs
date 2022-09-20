using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsManager : MonoBehaviour
{
 [SerializeField] Vector3 PosTarget;
 [SerializeField] Vector3 PosStart;
 public int idBg;
 GameObject _newCloud;
    public IEnumerator WaitTimeBornNewCloud()
    {
        BornNewCloud();
        while(true)
        {
            BornNewCloud();
            StartCoroutine(Move(_newCloud.transform, PosTarget, 20f));
            yield return new WaitForSeconds(20f);
        }
    }
  public  void BornNewCloud()
    {
        _newCloud = ObjectPooler._instance.SpawnFromPool("Cloud_0" + idBg, PosStart, Quaternion.Euler(0, 0, 0));
        if(transform.childCount>3)
        {
           GameObject FirstCloud = transform.GetChild(0).gameObject;
           ObjectPooler._instance.AddElement("Cloud_0" + idBg, FirstCloud);
           FirstCloud.transform.parent = ObjectPooler._instance.transform;

        }
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
