using TMPro;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("platform"))
        {
            TextMeshPro textMesh = other.transform.GetChild(0).GetComponent<TextMeshPro>();
            Color color;
            if (ColorUtility.TryParseHtmlString("#FF1E00", out color))
            {
                textMesh.color = color; 
            }
            //other.gameObject.SetActive(false);

            //CoreGameSignals.Instance.ss?.Invoke(other.gameObject);
        }
    }
}