using UnityEngine;
using UnityEngine.Events;

public class SoundSignals : MonoSingleton<SoundSignals>
{
    public UnityAction<SoundType, bool> onGetTriggerSound = delegate { };
}