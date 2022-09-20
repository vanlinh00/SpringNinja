using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Singleton<PlayerController>
{

    [SerializeField] GameObject _ninja;
    [SerializeField] SpringManager _springManager;

    private float _timeHold; // _timeHoldMax = 0.5668609
    private float _timeHoldMax = 0.5668609f;

    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _speedY;
    public float speedX;
    public bool isJump;
    [SerializeField] GameObject _collisionDetect;
    private int _currentScore;
    [SerializeField] int _countPassColumn;

    public bool isPlayerMove;
    private bool _canClick;
    public bool isOnGame;
    public float currentTimeHold;
   


    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _canClick = true;
        isPlayerMove = false;
        _currentScore = 0;
        _countPassColumn = 0;
        isJump = false;
        _timeHold = 0f;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckCanClick();

        if (_canClick == false)
        {
            return;
        }
        if (isOnGame)
        {
            if (Input.GetMouseButton(0) && !isJump && _timeHold <= _timeHoldMax)
            {
                _timeHold = _timeHold + Time.deltaTime;
                _springManager.SqueezeAllSpring();
               
                MoveHeroToHeaderSpring();
            }
            if (Input.GetMouseButtonUp(0))
            {
                Jump();
            }
        }
    
    }
    void CheckCanClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                _canClick = false;
            }
            else
            {
                _canClick = true;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                _canClick = false;
            }
            else
            {
                _canClick = true;
            }
        }
    }
    public  void MoveHeroToHeaderSpring()
    {
        _ninja.transform.position = new Vector3(_ninja.transform.position.x, _springManager.springL.GetPosHeader().y,0);
    }
    public void Jump()
    {
        if (_timeHold <= _timeHoldMax *1/ 4)
        {
            _speedY = 40f;
        }
        else if(_timeHold <= _timeHoldMax / 2)
        {
            _speedY = 34f;
        }
        else if (_timeHold <= _timeHoldMax* 3/ 4)
        {
            _speedY = 30f;
        }
        else
        {
            _speedY = 26f;
        }

        isPlayerMove = true;
        currentTimeHold = _timeHold;
        isJump = true;
        _collisionDetect.SetActive(true);
        _rigidbody.AddForce(new Vector2(0/*3*/, _timeHold * _speedY / _timeHoldMax), ForceMode2D.Impulse);
        SpringManager._instance.ResetScale();
        SpringManager._instance.MoveToHeader();
        _collisionDetect.transform.position = new Vector3(_ninja.transform.position.x, _ninja.transform.position.y - 0.0259576f, 0);
        _springManager.DisableSpring();
        _timeHold = 0f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
         {
            isPlayerMove = false;
            UiController._instance.EnableGameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MiddleCol"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void ChangeVelocity(Vector3 VectorChange)
    {
       _rigidbody.velocity = VectorChange;
    }
    public int GetCurrentPassColumn()
    {
        return _countPassColumn;
    }
    public void SetCurrentPassColumn()
    {
        _countPassColumn++;
    }
    public int GetCurrentScore()
    {
        return _currentScore;
    }
    public float GetTimeHold()
    {
        return _timeHold;
    }
   public float GetTimeHoldMax()
    {
        return _timeHoldMax;
    }
    public void SetCurrentScore()
    {
        if(_countPassColumn == 1)
        {
            _currentScore++;
        }
        else
        {
            _currentScore = _currentScore+ _countPassColumn * 2;
        }
        _countPassColumn = 0;
    }
    public float CalculerSpeedMove()
    {    
        if (currentTimeHold <= _timeHoldMax * 1 / 4f)
        {
            speedX = 2.3f;
        }
        else if (currentTimeHold <= _timeHoldMax / 2)
        {
            speedX = 1.75f;
        }
        else if (currentTimeHold <= _timeHoldMax * 3 / 4)
        {
            speedX = 2.2f;
        }
        else
        {
            speedX = 3.2f;
        }
        return speedX;
    }

}
