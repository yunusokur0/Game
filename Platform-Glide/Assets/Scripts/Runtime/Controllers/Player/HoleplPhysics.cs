using System.Collections;
using UnityEngine;

public class HoleplPhysics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pl"))
        {
            CoreGameSignals.Instance.OnRotateToFaceDown?.Invoke();
        }
    }
}