using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCol : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ColliderDetectPlayer"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
           // ColumnsController._instance.IsTouchMiddleCol = true;
        }
    }
}
