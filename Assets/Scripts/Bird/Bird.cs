using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private float _countTimeCheck = 0f;
    private float _maxTimeCheck = 0f;
    public Vector3 target;

    public Vector3 posLeft;
    public Vector3 posRight;
    public float _timeMove;
    public bool isFirstBird;
   public enum State
    {
        Move,
        Idle,
    }

    public State stateBird;
    private void Start()
    {
        isFirstBird = false;
        _timeMove = 1f;
        stateBird = State.Idle;
        _maxTimeCheck = 1f;
        _countTimeCheck = 0f;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target) <=0f)
        {
            stateBird = State.Idle;
            StateIdle();
        }

        if (stateBird!=State.Idle)
        {
            var step = 3f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else
        {
            AutoFlipAndJumb();
        }
       
    }
    public void AutoFlipAndJumb()
    {
        _countTimeCheck += Time.deltaTime;

        if (_countTimeCheck > _maxTimeCheck)
        {
            if (stateBird == State.Idle)
            {
                if (Random.RandomRange(1, 3) == 1)
                {
                    FilpLeft();

                    if (Random.RandomRange(1, 3) == 1)
                    {
                        JumbLeft();
                    }
                }
                else
                {
                    FilpRight();

                    if (Random.RandomRange(1, 3) == 1)
                    {
                        JumbRight();
                    }
                }
            }
            _countTimeCheck = 0f;
            _maxTimeCheck = 1f;
        }
    }
    public bool IsBirdOnLeft()
    {
        return (transform.position.x > 0f) ? false : true;
    }
    public void UpdateTarget()
    {
        if(!isFirstBird)
        {
            Vector3 PosHeaderCol = transform.parent.gameObject.GetComponent<Column>().PosHeader();
            target = new Vector3(PosHeaderCol.x, PosHeaderCol.y , 0f);
        }
    }
    void JumbLeft()
    {
           UpdateTarget();
           Vector3 NewPos = new Vector3(transform.position.x - Random.RandomRange(0.01f, 0.1f), transform.position.y, 0);
            if(Vector3.Distance(NewPos,target)<=0.15f)
            {
                transform.position = NewPos;
            }
    }
    void JumbRight()
    {
        UpdateTarget();
        Vector3 NewPos = new Vector3(transform.position.x + Random.RandomRange(0.01f, 0.1f), transform.position.y, 0);
        if(Vector3.Distance(NewPos,target)<=0.15f)
        {
            transform.position = NewPos;
        }
    }
    public void StateFlyDown()
    {
        //_animator.SetBool("FlyUp", false);
        //_animator.SetBool("FlyDown", true);
        _animator.SetBool("FlyUp", true);
    }
    public void StateFlyUp()
    {
        _animator.SetBool("FlyUp", true);
    }
    public void StateIdle()
    {
        _animator.SetBool("FlyDown", false);
        _animator.SetBool("FlyUp", false);
    }
    public void FilpRight()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    public void FilpLeft()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    public void MoveDown(bool IsFaceLeft)
    {
        if(IsFaceLeft)
        {
            FilpLeft();
        }
        else
        {
            FilpRight();
        }
        
        StateFlyDown();
        MoveToTarget(target);
    }
    public void MoveUp( bool IsFaceLeft)
    {
        if (IsFaceLeft)
        {
            FilpLeft();
        }
        else
        {
            FilpRight();
        }
        StateFlyUp();
        MoveToTarget(target);
    }
    public void MoveToTarget(Vector3 Target)
    {
        StartCoroutine(Move(transform, Target, _timeMove));
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ColliderDetectPlayer"))
        {
            if(!isFirstBird)
            {
                MoveToOutSide();
            }
             
        }
    }
    public void MoveToOutSide()
    {
        //GameObject CurrentCol = transform.parent.gameObject;
        //GameObject NextCol = CurrentCol.transform.parent.GetChild(CurrentCol.transform.GetSiblingIndex() + 1).gameObject;
        //gameObject.transform.parent = NextCol.transform;
        //UpdateTarget();
        //MoveUp(false);

        if (Random.RandomRange(1, 3) == 1)
        {
            target = posRight;
            MoveUp(false);
        }
        else
        {
            target = posLeft;
            MoveUp(true);
        }
        StartCoroutine(WaitTimeDisable());
    }
   public IEnumerator WaitTimeDisable()
    {
        yield return new WaitForSeconds(1f);
        ObjectPooler._instance.AddElement("Bird", this.gameObject);
        gameObject.transform.parent = ObjectPooler._instance.transform;
        gameObject.SetActive(false);
    }
}
