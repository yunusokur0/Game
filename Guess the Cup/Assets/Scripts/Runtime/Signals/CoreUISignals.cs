using UnityEngine.Events;

public class CoreUISignals : MonoSignleton<CoreUISignals>
{
    public UnityAction<byte> onClosePanel = delegate { };
    public UnityAction StartCountdown = delegate { };
    public UnityAction<UIPanelTypes, byte> onOpenPanel = delegate { };
}