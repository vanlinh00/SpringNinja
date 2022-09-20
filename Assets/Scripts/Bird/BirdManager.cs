using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] GameObject _bird_01;
    //[SerializeField] GameObject _bird_02;

    [SerializeField] GameObject _allColumns;
    [SerializeField] GameObject _player;

    Bird _bird1;
    //Bird _bird2;

    [SerializeField] Vector3 _posLeft;
    [SerializeField] Vector3 _posRight;

    bool _isClickPlay = false;
    float _countTimeFlip = 0f;

    void Start()
    {
        _bird1= _bird_01.GetComponent<Bird>();
        StartCoroutine(WaitTimeMoveToHero());
    }
    IEnumerator WaitTimeMoveToHero()
    {
        yield return new WaitForSeconds(1f);
        Vector3 Target = PlayerController._instance.PosHeaderHero();
        yield return new WaitForSeconds(1f);
        _bird1.MoveDown(Target);
        yield return new WaitForSeconds(2f);
        _bird1.Idle();
    }
    private void Update()
    {
        if(!_isClickPlay&&PlayerController._instance.isOnGame)
        {
            _isClickPlay = true;
            _bird1.MoveUp(_posRight);
        }
        //if(PlayerController._instance.isOnGame)
        //{
        //    _countTimeFlip++;
        //    if (_countTimeFlip == 2f)
        //    {
        //        _countTimeFlip = 0f;
        //        if (Random.RandomRange(1, 2) == 2)
        //        {
        //            _bird1.FilpRight();
        //        }
        //        else
        //        {
        //            _bird1.FilpLeft();

        //        }
        //    }
        //}
       
    }


}
