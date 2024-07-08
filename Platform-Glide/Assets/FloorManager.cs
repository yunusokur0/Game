using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FloorManager : MonoBehaviour
{
    public GameObject GreenFloor;
    public GameObject GreenFloor2;

    public GameObject greenline;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VibrationManager.Vibrate(50);
            GreenFloor2.SetActive(true);
            GreenFloor.transform.DOLocalMove(new Vector3(0, 1.5f, 0), 0.4f);
            UISignals.Instance.onSetCupText?.Invoke();
            CoreGameSignals.Instance.onStageAreaSuccessful?.Invoke();
            SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound);
            greenline.SetActive(false);

        }
    }

}