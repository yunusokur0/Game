using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource triggerAudioSource;
    [SerializeField] private AudioSource triggerAudioSource1;
    private CD_Sound _cdSound;

    private void Awake()
    {
        _cdSound = GetCD_Sound();
    }

    private CD_Sound GetCD_Sound() => Resources.Load<CD_Sound>("Data/CD_Sound");

    public void OnGetTriggerSound(SoundType type, bool isFirstSource)
    {
        AudioSource selectedSource = isFirstSource ? triggerAudioSource : triggerAudioSource1;
        SoundData soundData = _cdSound.SoundData.Find(sd => sd.Type == type);
        selectedSource.clip = soundData.Clip;
        selectedSource.Play();
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
