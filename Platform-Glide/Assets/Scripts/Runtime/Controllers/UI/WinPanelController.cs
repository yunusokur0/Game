using TMPro;
using UnityEngine;


public class WinPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cupText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;



    private void Start()
    {
        scoreText.text = "Score: " + UISignals.Instance.score.ToString();
    }
}