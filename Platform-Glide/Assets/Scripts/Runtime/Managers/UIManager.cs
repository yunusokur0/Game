using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnPlay()
    {
        CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(1);
        CoreGameSignals.Instance.onPlay?.Invoke();
    }

    private void OnLevelInitialize(byte levelValue)
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 0);
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
    }

    public void OnNextLevel()
    {
        CoreUISignals.Instance.onClosePanel?.Invoke(3);
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 0);
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onNextLevel?.Invoke();
    }

    public void OnRestartLevel()
    {
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onRestartLevel?.Invoke();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}