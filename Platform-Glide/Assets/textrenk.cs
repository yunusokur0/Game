using TMPro;
using UnityEngine;
using DG.Tweening;

public class textrenk : MonoBehaviour
{
    public GameObject bir;
    public GameObject iki;
    public TextMeshPro plattext;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (plattext != null)
            {
                plattext.DOColor(Color.green, 0.25f);
            }

            UISignals.Instance.score++;
            if (bir != null && iki != null)
            {
                bir.transform.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.7f);
                iki.transform.GetComponent<SpriteRenderer>().DOColor(Color.green, 0.35f);
            }
        }
    }
}