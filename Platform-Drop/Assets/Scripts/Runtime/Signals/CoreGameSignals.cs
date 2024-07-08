using System;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoSingleton<CoreGameSignals>
{
    public UnityAction<byte> onLevelInitialize = delegate { };
    public UnityAction onStageAreaSuccessful = delegate { };
    public UnityAction onRotateToFaceDown = delegate { };
    public UnityAction onSetCameraTarget = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
    public UnityAction onPlay = delegate { };
    public UnityAction onReset = delegate { };
    public UnityAction<bool> sff = delegate { };
    public UnityAction<int> nnn = delegate { };
    public UnityAction<GameObject> ss = delegate { };

}