using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupsManager : MonoBehaviour
{
    #region veriable
    private float _cupMovementTime = 0f;
    private bool _reachedTarget = false;
    private bool _firstMove = false;

    public float CupMovementTime
    {
        get { return _cupMovementTime; }
        set { _cupMovementTime = value; }
    }

    public bool ReachedTarget
    {
        get { return _reachedTarget; }
        set { _reachedTarget = value; }
    }

    public bool First
    {
        get { return _firstMove; }
        set { _firstMove = value; }
    }

    public List<GameObject> cupList;
    public Material cupMaterial;
    public float speed;
    public byte objCount;

    public List<GameObject> temporaryCupList = new List<GameObject>();
    public List<GameObject> chosenCupList = new List<GameObject>();
    public List<float> distance = new List<float>();
    public List<Vector3> cupTransform = new List<Vector3>();
    public List<Vector3> C4pTransform = new List<Vector3>();

    public byte _loopCount = 0;
    public float _randomValue;
    private MoveX _moveX;
    private MoveYX _moveYX;

    public IState CurrentState;
    private ObjeCountTwo _ObjeCountTwo;
    private ObjeCountThree _ObjeCountThree;
    private ObjeCountFour _ObjeCountFour;
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _moveX = new MoveX(this, speed);
        _moveYX = new MoveYX(this, speed);
        _ObjeCountTwo = new ObjeCountTwo(this, _moveX, _moveYX);
        _ObjeCountThree = new ObjeCountThree(this, _moveX, _moveYX);
        _ObjeCountFour = new ObjeCountFour(this, _moveX);
    }

    public void StartCoroutine()
    {
        StartCoroutine(SelectRandomCups());
        ChangeMaterials();
    }

    private void ChangeMaterials()
    {
        foreach (var obj in cupList)
        {
            var renderer = obj.GetComponent<Renderer>();

            if (renderer != null)
                renderer.material = cupMaterial;
        }
    }

    private IEnumerator SelectRandomCups()
    {
        while (_loopCount < 7)
        {
            objCount = (byte)Random.Range(2, _firstMove ? 4 : 5);
            _randomValue = Random.value;

            temporaryCupList = new List<GameObject>(cupList);

            curretnsate();
            CurrentState.EnterState();

            _reachedTarget = false;
            _cupMovementTime = 0;

            yield return new WaitForSeconds(2.2f);
            ClearList();
            _loopCount++;
            _firstMove = true;

            if (_loopCount >= 2)
                CoreGameSignals.Instance.onFindBall?.Invoke(true);
        }
    }

    private void ClearList()
    {
        chosenCupList.Clear();
        chosenCupList.TrimExcess();
        cupTransform.Clear();
        cupTransform.TrimExcess();
        temporaryCupList.Clear();
        temporaryCupList.TrimExcess();
    }

    private void curretnsate()
    {
        switch (objCount)
        {
            case 2:
                CurrentState = _ObjeCountTwo;
                break;
            case 3:
                CurrentState = _ObjeCountThree;
                break;
            case 4:
                CurrentState = _ObjeCountFour;
                break;
        }
    }

    private void Update()
    {
        if (!_firstMove)
        {
            FirstMove();
        }

        else
        {
            AllMove();
        }

    }

    public void FirstMove()
    {
        if (chosenCupList.Count > 0 || C4pTransform.Count>0)
        {
            CurrentState.MoveX();
        }
    }

    public void AllMove()
    {
        if (chosenCupList.Count > 0)
        {
            if (_randomValue < .9f)
            {
                CurrentState.MoveX();
            }

            else
            {
                CurrentState.MoveYX();
            }
        }
    }

    private void onrest()
    {
        _loopCount = 0;
        _reachedTarget = true;
        _firstMove = false;
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CupSignals.Instance.StartCoroutineCups += StartCoroutine;
        CoreGameSignals.Instance.onReset += onrest;
    }

    private void UnsubscribeEvents()
    {
        CupSignals.Instance.StartCoroutineCups -= StartCoroutine;
        CoreGameSignals.Instance.onReset -= onrest;
    }
    private void OnDisable() => UnsubscribeEvents();
}