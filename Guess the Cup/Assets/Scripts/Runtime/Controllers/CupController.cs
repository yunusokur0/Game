using System.Collections;
using UnityEngine;

public class CupController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public GameObject Ball;

    public void EnableCupPhysics()
    {
        rb.isKinematic = false;
    }

    public void OnStartBallControlCoroutine()
    {
        StartCoroutine(HandleCupControl());
    }

    IEnumerator HandleCupControl()
    {
        if (Ball != null)
        {
            Ball.transform.SetParent(null);
            yield return new WaitForSeconds(0.5f);
            Ball.GetComponent<BoxCollider>().enabled = true;
            Ball = null;
        }
    }

    private void OnEnable()
    {
        SubscribeEvent();
    }
    private void SubscribeEvent()
    {
        CupSignals.Instance.onStartBallControlCoroutine += OnStartBallControlCoroutine;
        CoreGameSignals.Instance.onGamePlayStarted += EnableCupPhysics;
    }
    private void UnSubscribeEvent()
    {
        CupSignals.Instance.onStartBallControlCoroutine -= OnStartBallControlCoroutine;
        CoreGameSignals.Instance.onGamePlayStarted -= EnableCupPhysics;
    }
    private void OnDisable()
    {
        UnSubscribeEvent();
    }
}