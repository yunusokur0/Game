using Cinemachine;
using DG.Tweening;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public Vector3 _firstPosition;
    public Quaternion _firstRotation;

//
    public void RotateToFaceDown()
    {
        transform.DOShakeRotation(1f, 2f).OnComplete(() =>
        {
            CoreUISignals.Instance.onClosePanel?.Invoke(0);
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 3);
        });
        VibrationManager.Vibrate(85);
        PlayerSignals.Instance.onPlayConditionChanged?.Invoke(false);
      
    }
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        CoreGameSignals.Instance.onReset += OnReset;
        CoreGameSignals.Instance.OnRotateToFaceDown += RotateToFaceDown;
    }

    private void OnSetCameraTarget()
    {
        var player = FindObjectOfType<PlayerManager>().transform;
        virtualCamera.Follow = player;
    }

    private void OnReset()
    {
        UISignals.Instance.score = 0;
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        virtualCamera.transform.localPosition = _firstPosition;
        virtualCamera.transform.rotation = _firstRotation;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        CoreGameSignals.Instance.onReset -= OnReset;
        CoreGameSignals.Instance.OnRotateToFaceDown -= RotateToFaceDown;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
