using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    private void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        countdownText.text = 3.ToString();
        countdownText.DOColor(Color.red, 0);
        yield return new WaitForSeconds(.6f);

        countdownText.text = 2.ToString();
        Color orange = new Color(1f, 0.64f, 0f, 1f);
        countdownText.DOColor(orange, 0);
        yield return new WaitForSeconds(.6f);

        countdownText.text = 1.ToString();
        countdownText.DOColor(Color.green, 0);
        yield return new WaitForSeconds(.6f);

        CupSignals.Instance.StartCoroutineCups?.Invoke();
        CoreUISignals.Instance.onClosePanel?.Invoke(1);
    }
}