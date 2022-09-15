using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{

    [SerializeField] GameObject _ninja;
    [SerializeField] SpringManager _springManager;

    private float _timeHold;   // _timeHoldMax = 0.5668609
    private float _timeHoldMax = 0.5668609f;

    public Rigidbody2D rigidbody;

    [SerializeField] float _speedY;
    [SerializeField] float _speedX;
    public bool isJump;

    [SerializeField] GameObject CollisionDetect;

    private float _currentScore;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _currentScore = 0f;
        isJump = false;
        _timeHold = 0f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !isJump && _timeHold<= _timeHoldMax)
        {
            _timeHold = _timeHold + Time.deltaTime;
            _springManager.SqueezeAllSpring();
            MoveHeroToHeaderSpring();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isJump = true;
            rigidbody.AddForce(new Vector2(_speedX, _speedY * _timeHold), ForceMode2D.Impulse);
            SpringManager._instance.ResetScale();
            SpringManager._instance.MoveToHeader();
            CollisionDetect.transform.position = _ninja.transform.position; 
            _springManager.DisableSpring();
            _timeHold = 0f;
        }
    }

  public  void MoveHeroToHeaderSpring()
    {
        _ninja.transform.position = new Vector3(_ninja.transform.position.x, _springManager.springL.GetPosHeader().y,0);
    }
    public void Fjump(float jump1)
    {
        rigidbody.AddForce(new Vector2(0, jump1), ForceMode2D.Impulse);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _currentScore++;
        Debug.Log(_currentScore);
    }

}
