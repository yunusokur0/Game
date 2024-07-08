using UnityEngine.Events;

public class PlayerSignals : MonoSingleton<PlayerSignals>
{
    public UnityAction<bool> onPlayConditionChanged = delegate { };
    public UnityAction<bool> onMoveConditionChanged = delegate { };
}