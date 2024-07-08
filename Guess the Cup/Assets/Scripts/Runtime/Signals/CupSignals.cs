using UnityEngine.Events;

public class CupSignals : MonoSignleton<CupSignals>
{
    public UnityAction onStartBallControlCoroutine = delegate { };
    public UnityAction StartCoroutineCups = delegate { };
}
