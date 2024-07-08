using DG.Tweening;
using UnityEngine;

public class PlayerScaleController : MonoBehaviour
{
    private float _inputValue;
    private PlayerData _data;
    public bool _isReadyToMove, _isReadyToPlay;
    private const string PlayerDataPath = "Data/CD_Player";

    public bool bos = false;

    private void Awake()
    {
        _data = GetPlayerData();
    }

    private PlayerData GetPlayerData() => Resources.Load<CD_Player>(PlayerDataPath).Data;

    public void OnInputDragged(HorizontalInputParams inputParams)
    {
        _inputValue = inputParams.HorizontalValue;
    }

    private void Update()
    {
        if (_isReadyToPlay)
        {
            if (_isReadyToMove)
            {
                if (bos == false)
                    CalculateNewScale(_inputValue);

                else if (bos)
                {
                    if (_inputValue <= -1f)
                    {
                        transform.DOScale(new Vector3(3.25f, transform.localScale.y, 3.25f), .15f);
                    }

                    else if (_inputValue >= 1f)
                    {
                        transform.DOScale(new Vector3(5.4f, transform.localScale.y, 5.4f), .15f);
                    }
                }
            }
            else
            {

            }
        }
    }

    private void CalculateNewScale(float inputValue)
    {
        float xScaleShiftAmout = inputValue * _data.SidewaysSpeed * Time.deltaTime;
        float yScaleShiftAmout = inputValue * _data.SidewaysSpeed * Time.deltaTime;

        SetNewScale(xScaleShiftAmout, yScaleShiftAmout);
    }

    private void SetNewScale(float xScaleShiftAmout, float yScaleShiftAmout)
    {
        Vector3 newScale = transform.localScale + new Vector3(xScaleShiftAmout, 0, yScaleShiftAmout);
        newScale.x = Mathf.Clamp(newScale.x, _data.ClampSides.x, _data.ClampSides.y);
        newScale.z = Mathf.Clamp(newScale.z, _data.ClampSides.x, _data.ClampSides.y);
        transform.localScale = newScale;
    }

    private void OnPlayConditionChanged(bool condition) => _isReadyToPlay = condition;
    private void OnMoveConditionChanged(bool condition) => _isReadyToMove = condition;

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged += OnPlayConditionChanged;
        PlayerSignals.Instance.onMoveConditionChanged += OnMoveConditionChanged;
        InputSignals.Instance.onInputDragged += OnInputDragged;
    }

    private void UnSubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged -= OnPlayConditionChanged;
        PlayerSignals.Instance.onMoveConditionChanged -= OnMoveConditionChanged;
        InputSignals.Instance.onInputDragged -= OnInputDragged;
    }
    private void OnDisable() => UnSubscribeEvents();
}