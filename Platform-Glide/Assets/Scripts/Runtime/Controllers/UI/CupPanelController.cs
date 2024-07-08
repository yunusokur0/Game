using System.Collections;
using TMPro;
using UnityEngine;


public class CupPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cupText;
    private int currentCupValue;

    private void OnSetCupText(int value)
    {
        currentCupValue += value;
        cupText.text = currentCupValue.ToString();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {

        UISignals.Instance.onGetCupText += OnSetCupText;
    }

    private void UnSubscribeEvents()
    {

        UISignals.Instance.onGetCupText -= OnSetCupText;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
