using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : Singleton<SpringManager>
{
    [SerializeField] GameObject _springRight;
    [SerializeField] GameObject _springLeft;

    public  Spring _springR;
    public  Spring springL;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _springR = _springRight.GetComponent<Spring>();
        springL = _springLeft.GetComponent<Spring>();
    }

   public void SqueezeAllSpring()
    {
        _springR.SqueezeSpring();
        springL.SqueezeSpring();
    }
    public void StretchAllSpring()
    {
        _springR.isStretch = true;
        springL.isStretch = true;
    }
    public void ResetScale()
    {
        _springR.ResetScale();
        springL.ResetScale();
    }
    public void MoveToHeader()
    {
        _springR.MoveToHeader();
        springL.MoveToHeader();
    }
    
    public void DisableSpring()
    {
        gameObject.SetActive(false);
    }
    public void EnableSpring()
    {
        gameObject.SetActive(true);
    }
}
