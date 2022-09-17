using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool IsTouchHeaderColision;

    //void Update()
    //{
    //    RaycastHit2D hitdown = Physics2D.Raycast(transform.position, -transform.up, 0.05f);
    //    if (hitdown.collider != null)
    //    {
    //        if (hitdown.collider.gameObject.CompareTag("Column"))
    //        {
    //            Column col = hitdown.collider.gameObject.GetComponent<Column>();
    //            if (!col.isPlayerStanding)
    //            {
    //                PlayerController._instance.isPlayerMove = false;
    //                PlayerController._instance.ChangeVelocity(Vector3.zero);

    //                //if(col.PosHeader().y<= this.gameObject.transform.position.y)
    //                // {
    //                PlayerController._instance.SetCurrentScore();
    //                GamePlay._instance.UpdateCurretScore();
    //                SpringManager._instance.EnableSpring();
    //                SpringManager._instance.StretchAllSpring();
    //                StartCoroutine(WaitContinueGame());
    //                //  }
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeaderColDetect"))
        {
            IsTouchHeaderColision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeaderColDetect"))
        {
            IsTouchHeaderColision = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("HeaderCol"))
        {
            HeaderCol Headercol = collision.gameObject.GetComponent<HeaderCol>();

            if (!Headercol.isPlayerStanding)
            {
                Headercol.isPlayerStanding = true;

                PlayerController._instance.isPlayerMove = false;

                if (IsTouchHeaderColision)
                {
                    IsTouchHeaderColision = false;

                    this.gameObject.SetActive(false);

                    PlayerController._instance.SetCurrentScore();
                    GamePlay._instance.UpdateCurretScore();
                    SpringManager._instance.EnableSpring();
                    SpringManager._instance.StretchAllSpring();
                    PlayerController._instance.ChangeVelocity(Vector3.zero);
                    PlayerController._instance.isJump = false;
                    ColumnsController._instance.BornNewColumn(PlayerController._instance.GetCurrentPassColumn());
                }

            }
        }
    }

}
