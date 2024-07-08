using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    private byte inE = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("pl"))
        {
            CoreGameSignals.Instance.onRotateToFaceDown?.Invoke();
        }
        if(other.CompareTag("cs"))
        {
            inE++;
            if(inE>=3)
            {
                SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound, true);
                inE = 1;
            }
        }
    }
}