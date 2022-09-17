using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPassCol : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColliderDetectPlayer"))
        {
            PlayerController._instance.SetCurrentPassColumn();
            gameObject.SetActive(false);
        }

    }
}
