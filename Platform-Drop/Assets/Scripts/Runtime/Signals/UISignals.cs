using UnityEngine.Events;

public class UISignals : MonoSingleton<UISignals>
{
    public UnityAction<int> onSetLevelText = delegate { };
    public UnityAction<int> onGetCupText = delegate { };
    public UnityAction onGetScoreText = delegate { };
    public UnityAction onSetCupText = delegate { };
    public UnityAction<byte> onSetStageColor = delegate { };
}