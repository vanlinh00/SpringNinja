using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : Singleton<BirdManager>
{
    [SerializeField] GameObject _firstBird;

    [SerializeField] GameObject _allColumns;
    [SerializeField] GameObject _player;

    Bird _bird1;

    [SerializeField] Vector3 _posLeft;
    [SerializeField] Vector3 _posRight;

    bool _isClickPlay = false;

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _bird1= _firstBird.GetComponent<Bird>();
        if (!DataPlayer.GetInforPlayer().isLoadGameAgain)
        {
            StartCoroutine(WaitTimeMoveToHero());
        }
        else
        {
            _firstBird.SetActive(false);
        }
    }
    IEnumerator WaitTimeMoveToHero()
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 Target = PlayerController._instance.PosHeaderHero();
        yield return new WaitForSeconds(0.3f);
        _bird1.isFirstBird = true;
        _bird1.target = Target;
        _bird1.stateBird = Bird.State.Move;
        _bird1.StateFlyDown();
        // _bird1.MoveDown(false);
        //if (!_isClickPlay)
        //{
        //    yield return new WaitForSeconds(1f);
        //    _bird1.stateBird = Bird.State.Idle;
        //    _bird1.StateIdle();
        //}
    }
    private void Update()
    {
        if(!_isClickPlay&&PlayerController._instance.isOnGame)
        {
            _isClickPlay = true;
            
            if(Random.RandomRange(1,3)==1)
            {
                _bird1.target = _posRight;
                _bird1.stateBird = Bird.State.Move;
                _bird1.StateFlyUp();
                _bird1.FilpRight();
                //_bird1.MoveUp(false);
            }
            else
            {
                _bird1.target = _posLeft;
                _bird1.stateBird = Bird.State.Move;
                _bird1.StateFlyUp();
                _bird1.FilpLeft();
            }

        }
    } 
  public GameObject MoveBirdOnColumns(Vector3 PosBird)
    {
        GameObject NewBird = ObjectPooler._instance.SpawnFromPool("Bird", PosBird, Quaternion.Euler(0, 0, 0));
        Bird newBirdSc = NewBird.GetComponent<Bird>();
        newBirdSc.posLeft = _posLeft;
        newBirdSc.posRight = _posRight;
        newBirdSc.target = PosBird;

        //    int NumberCol = Random.RandomRange(1, 3);
        //    Vector3 PosHeaderCol = _allColumns.transform.GetChild(NumberCol).GetComponent<Column>().PosHeader();
        //    _bird1.StateIdle();
        //    Vector3 PosBird = new Vector3(PosHeaderCol.x, PosHeaderCol.y+2f, 0f);
        //    _bird1.posLeft = _posLeft;
        //    _bird1.posRight = _posRight;
        //    _bird1.target = PosBird;
        //    _bird1.transform.position = PosHeaderCol;
        return NewBird;
    }
}
