using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    private float _minScale = 0.01522093f;      
    private float _maxScale = 0.4862621f;      
    [SerializeField] float _speed = 1f;

    [SerializeField] GameObject _header;
    [SerializeField] GameObject _middle;
    [SerializeField] GameObject _footer;

    public bool isStretch;
    public void Start()
    {
        isStretch = false;
    }
    private void FixedUpdate()
    {
        if (isStretch)
        {
            StretchSpring();
            PlayerController._instance.MoveHeroToHeaderSpring();
        }
    }

    float a = 0;
    public void SqueezeSpring()
    {
        if(_middle.transform.lossyScale.x> _minScale)
        {
            a =a+ Time.deltaTime;
            _middle.transform.localScale = new Vector3(_middle.transform.lossyScale.x - Time.deltaTime / _speed, _middle.transform.lossyScale.y, 0);
            _header.transform.position = new Vector3(_header.transform.position.x, _middle.transform.position.y + _middle.transform.lossyScale.x * 0.7399999f, 0);
        }
        else
        {
            Debug.Log(a);
        }
    }
    public void StretchSpring()
    {
        if (_middle.transform.lossyScale.x < _maxScale)
        {
            _middle.transform.localScale = new Vector3(_middle.transform.lossyScale.x + 2f* Time.deltaTime / _speed, _middle.transform.lossyScale.y, 0);
            _header.transform.position = new Vector3(_header.transform.position.x, _middle.transform.position.y + _middle.transform.lossyScale.x * 0.7399999f, 0);
        }
        else
        {
            isStretch = false;
        }
    }    
    public void ResetScale()
    {
        _middle.transform.localScale = new Vector3(_minScale ,_middle.transform.lossyScale.y, 0);
    }
    public Vector3 GetPosHeader()
    {
        return new Vector3( _header.transform.position.x,_header.transform.position.y+ 0.030389886f/2,0);
    }
    public void MoveToHeader()
    {
        _footer.transform.position = _header.transform.position;
        _middle.transform.position = _header.transform.position;
    }
    public GameObject GetHeader()
    {
        return _header;
    }
    public GameObject GetFooter()
    {
        return _footer;
    }

}
