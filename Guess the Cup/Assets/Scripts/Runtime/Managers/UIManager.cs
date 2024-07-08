using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        OnPlayStart();
    }
    private void OnPlayStart()
    {
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
    }
    public void OnPlay()
    {
        CoreGameSignals.Instance.onGamePlayStarted?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(0);
        CoreGameSignals.Instance.onSelectAndPlaceBall?.Invoke();
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.CountDown, 1);
        //CoreUISignals.Instance.StartCountdown?.Invoke();
    }

    public void OnRestartLevel()
    {
        CoreGameSignals.Instance.onRestartLevel?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(2);
        CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
        CoreGameSignals.Instance.onReset?.Invoke();
    }
}