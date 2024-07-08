using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void OnPlay()
    {
        PlayerSignals.Instance.onPlayConditionChanged?.Invoke(true);
        PlayerSignals.Instance.asdasd?.Invoke();
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputTaken += () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(true);
        InputSignals.Instance.onInputReleased += () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(false);
        CoreGameSignals.Instance.onPlay += OnPlay;
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputTaken -= () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(true);
        InputSignals.Instance.onInputReleased -= () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(false);
        CoreGameSignals.Instance.onPlay -= OnPlay;
    }
    private void OnDisable() => UnSubscribeEvents();
}