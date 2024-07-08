using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloorPhysicsController : MonoBehaviour
{
    [SerializeField] private TextMeshPro floorText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floorText.DOColor(Color.green, 0.15f);
            UISignals.Instance.onGetScoreText?.Invoke();
        }
    }
}