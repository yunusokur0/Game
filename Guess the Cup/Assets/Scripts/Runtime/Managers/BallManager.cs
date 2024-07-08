using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private CupsManager cupsManager;
    [SerializeField] private GameObject ball;

    private void OnSelectAndPlaceBall()
    {
        int selectedIndex = Random.Range(0, cupsManager.cupList.Count);
        GameObject selectedObj = cupsManager.cupList[selectedIndex];

        Vector3 ballPosition = selectedObj.transform.position;
        ballPosition.y = 5.75f;
        ball.transform.position = ballPosition;
        ball.SetActive(true);
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onSelectAndPlaceBall += OnSelectAndPlaceBall;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onSelectAndPlaceBall -= OnSelectAndPlaceBall;
    }
    private void OnDisable() => UnsubscribeEvents();
}