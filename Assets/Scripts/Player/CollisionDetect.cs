using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool isTouchHeaderColision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeaderColDetect"))
        {
            isTouchHeaderColision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeaderColDetect"))
        {
            isTouchHeaderColision = false;
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

                if (isTouchHeaderColision)
                {

                    SoundController._instance.OnPlayAudio(SoundType.land);
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    isTouchHeaderColision = false;
                    int AmountColPass = PlayerController._instance.GetCurrentPassColumn();

                    ColumnsController._instance.AddOldColumnToPool(AmountColPass);
                    ColumnsController._instance.BornNewColumn(AmountColPass);
                    OnEnbleAddScoreTxt(AmountColPass);

                    BackGroundDynamic._instance.BornNewMountain();
                    WaweManager._instance.WaitLoadAllWawe();
                    BackGroundDynamic._instance.BornNewLeaf();
                    BackGroundDynamic._instance.GetCloudsMangaer().BornNewCloud();
                    bool IsPlayerOnEgdeColumn = Headercol.IsPlayerStandOnEgdeColumn(SpringManager._instance.springL.PosHeaderFooterLeft(), SpringManager._instance.springR.PosHeaderFooterRight());
                    StartCoroutine(FadeTimeChangeState(IsPlayerOnEgdeColumn));

                }

            }
        }
    }
    IEnumerator FadeTimeChangeState(bool IsPlayerStandOnEgdeColumn)
    {
        if(IsPlayerStandOnEgdeColumn)
        {
            PlayerController._instance.StateSweat();
        }
        PlayerController._instance.SetCurrentScore();
        GamePlay._instance.UpdateCurretScore();
        SpringManager._instance.EnableSpring();
        SpringManager._instance.StretchAllSpring();
        PlayerController._instance.ChangeVelocity(Vector3.zero);
        yield return new WaitForSeconds(0.3f);
        PlayerController._instance.StateIdle();
        PlayerController._instance.isJump = false;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
   void OnEnbleAddScoreTxt(int AmountColPass)
    {
        if(AmountColPass>=2)
        {
            StartCoroutine(GamePlay._instance.WaitTimeDisableAddScoreTxt(AmountColPass*2));
        }
    }
  
}
