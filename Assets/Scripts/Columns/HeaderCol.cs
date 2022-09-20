using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderCol : MonoBehaviour
{
    public bool isPlayerStanding;
    void Start()
    {
        isPlayerStanding = false;
    }
    Vector3 GetPosLeft()
    {
        return new Vector3(transform.parent.position.x - 0.24304706363f, transform.parent.position. y+ 3.310000317f,0);
    }
    Vector3 GetPosRight()
    {
        return new Vector3(transform.parent.position.x + 0.24304706363f, transform.parent.position.y + 3.310000317f,0);
    }
   public bool IsPlayerStandOnEgdeColumn(Vector3 SpringLeft, Vector3 SpringRight)
    {
        Debug.Log(GetPosLeft());
        return (Vector3.Distance(SpringRight, GetPosLeft()) <= 0.15 || (Vector3.Distance(SpringLeft, GetPosRight()) <= 0.15f) )? true : false;
    }
}
