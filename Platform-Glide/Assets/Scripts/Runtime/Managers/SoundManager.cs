using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource triggerAudioSource;
    private CD_Sound _cdSound;

    private void Awake()
    {
        _cdSound = GetCD_Sound();
    }

    private CD_Sound GetCD_Sound() => Resources.Load<CD_Sound>("Data/CD_Sound");

    public void OnGetTriggerSound(SoundType type)
    {
        SoundData soundData = _cdSound.SoundData.Find(sd => sd.Type == type);
        triggerAudioSource.clip = soundData.Clip;
        triggerAudioSource.Play();
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        SoundSignals.Instance.onGetTriggerSound += OnGetTriggerSound;
    }

    private void UnSubscribeEvents()
    {
        SoundSignals.Instance.onGetTriggerSound -= OnGetTriggerSound;
    }
    private void OnDisable() => UnSubscribeEvents();
}