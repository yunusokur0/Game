using UnityEngine.Events;

public class SoundSignals : MonoSingleton<SoundSignals>
{
    public UnityAction<SoundType> onGetTriggerSound = delegate { };
}