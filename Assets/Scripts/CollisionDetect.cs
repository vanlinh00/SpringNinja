using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void Update()
    {
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, -transform.up, 0.05f);

        if (hitdown.collider != null)
        {
            if (hitdown.collider.gameObject.CompareTag("Column"))
            {
                Column col = hitdown.collider.gameObject.GetComponent<Column>();
                if (!col.isPlayerStanding)
                {
                    PlayerController._instance.rigidbody.velocity = Vector3.zero;
                    SpringManager._instance.EnableSpring();
                    SpringManager._instance.StretchAllSpring();
                    StartCoroutine(WaitContinueGame());

                }
            }
        }

    }
    IEnumerator WaitContinueGame()
    {
        yield return new WaitForSeconds(0.6f);
        PlayerController._instance.isJump = false;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Column"))
    //    {
    //        PlayerController._instance.rigidbody.velocity = Vector3.zero;
    //        SpringManager._instance.EnableSpring();
    //        SpringManager._instance.StretchAllSpring();
    //        StartCoroutine(WaitContinueGame());
    //    }
    //}
}
