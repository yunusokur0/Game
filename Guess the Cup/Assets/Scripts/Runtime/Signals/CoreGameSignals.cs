using System;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoSignleton<CoreGameSignals>
{
    public UnityAction<byte> onLevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction<bool> onFindBall = delegate { };
    public UnityAction onGamePlayStarted = delegate { };
    public UnityAction onReset = delegate { };
    public UnityAction onSelectAndPlaceBall = delegate { };
    public Func<GameObject> onGetEnemyTarget = delegate { return default; };
    public UnityAction onRestartLevel = delegate { };
}