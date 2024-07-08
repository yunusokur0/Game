using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private List<Image> stageImages = new List<Image>();

    private int currentScoreValue;


    private void Awake()
    {
        OnGetScoreText(currentScoreValue);
    }

    private void OnSetLevelText(int value)
    {
        levelText.text = "Level " + (value + 1);
    }

    private void OnSetStageColor(byte stageValue)
    {
        stageImages[stageValue].DOColor(new Color(0, 255, 0), 0.7f);
    }

    private void OnGetScoreText(int value)
    {
        currentScoreValue += value;
        scoreText.text = currentScoreValue.ToString();
        scoreTextObject.transform.DOScale(new Vector3(1.4f,1.4f,1.4f),.35f).OnComplete(() =>
        {
            scoreTextObject.transform.DOScale(new Vector3(1f, 1f, 1f),.35f);
        });
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetLevelText += OnSetLevelText;
        UISignals.Instance.onSetStageColor += OnSetStageColor;
        UISignals.Instance.onGetScoreText += OnGetScoreText;
    }

    private void UnSubscribeEvents()
    {
        UISignals.Instance.onSetLevelText -= OnSetLevelText;
        UISignals.Instance.onSetStageColor -= OnSetStageColor;
        UISignals.Instance.onGetScoreText -= OnGetScoreText;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}