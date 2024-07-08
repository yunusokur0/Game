using UnityEngine.Events;

public class CoreGameSignals : MonoSingleton<CoreGameSignals>
{
    public UnityAction<byte> onLevelInitialize = delegate { };
    public UnityAction onStageAreaSuccessful = delegate { };
    public UnityAction onSetCameraTarget = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
    public UnityAction onPlay = delegate { };
    public UnityAction OnRotateToFaceDown = delegate { };
    public UnityAction onReset = delegate { };
    public UnityAction<int> nnn = delegate { };
}