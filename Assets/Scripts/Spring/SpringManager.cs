using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : Singleton<SpringManager>
{
    [SerializeField] GameObject _springRight;
    [SerializeField] GameObject _springLeft;

    public Spring springR;
    public Spring springL;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        springR = _springRight.GetComponent<Spring>();
        springL = _springLeft.GetComponent<Spring>();
    }
   public void SqueezeAllSpring()
    {
        springR.SqueezeSpring();
        springL.SqueezeSpring();
    }
    public void StretchAllSpring()
    {
        springR.isCompress = true;
        springL.isCompress = true;
    }
    public void ResetScale()
    {
        springR.ResetScale();
        springL.ResetScale();
    }
    public void MoveToHeader()
    {
        springR.MoveToHeader();
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
