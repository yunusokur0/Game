using TMPro;
using UnityEngine;

public class ScorePanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int score = 0;
    private int bestScore = 0;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text =  score.ToString();

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best Score: " + bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onGetScoreText += IncreaseScore;
    }

    private void UnSubscribeEvents()
    {
        UISignals.Instance.onGetScoreText -= IncreaseScore;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
