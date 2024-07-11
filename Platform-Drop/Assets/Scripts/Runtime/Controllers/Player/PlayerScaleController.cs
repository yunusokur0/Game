using UnityEngine;
using DG.Tweening;

public class PlayerScaleController : MonoBehaviour
{
    private bool _isReadyToMove, _isReadyToPlay;

    private void Update()
    {
        if (_isReadyToPlay)
        {
            if (_isReadyToMove)
            {
                transform.DOScale(new Vector3(3.25f, 0.4f, 3.25f), .15f);
            }

            else  if (!_isReadyToMove)
            {              
                transform.DOScale(new Vector3(5.4f, 0.20f, 5.4f), .15f);
            }
        }
    }


    private void OnPlayConditionChanged(bool condition) => _isReadyToPlay = condition;
    private void OnMoveConditionChanged(bool condition) => _isReadyToMove = condition;

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged += OnPlayConditionChanged;
        PlayerSignals.Instance.onMoveConditionChanged += OnMoveConditionChanged;
    }

    private void UnSubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged -= OnPlayConditionChanged;
        PlayerSignals.Instance.onMoveConditionChanged -= OnMoveConditionChanged;
    }
    private void OnDisable() => UnSubscribeEvents();
}
