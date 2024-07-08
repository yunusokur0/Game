using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnPlay()
    {
        CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(0);
        CoreGameSignals.Instance.onPlay?.Invoke();
    }

    private void OnLevelInitialize(byte levelValue)
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Score, 1);
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Settings, 2);
    }

    public void OnNextLevel()
    {
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onNextLevel?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(3);
        CoreGameSignals.Instance.sff?.Invoke(false);
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