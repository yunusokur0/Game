using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public Vector3 _firstPosition;
    public Quaternion _firstRotation;

    public Camera kamera;

    void Start()
    {
        RastgeleRenkAta();
    }

    void RastgeleRenkAta()
    {
        Color rastgeleRenk = new Color(Random.value, Random.value, Random.value);
        kamera.backgroundColor = rastgeleRenk;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        CoreGameSignals.Instance.onRotateToFaceDown += RotateToFaceDown;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    public void RotateToFaceDown()
    {
        virtualCamera.transform.DOShakePosition(1.7f, new Vector3(1, 2f, 10f));
        transform.DOShakeRotation(1.7f, new Vector3(1, 2f, 2f)).OnComplete(() =>
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 3);
        });
        PlayerSignals.Instance.onPlayConditionChanged?.Invoke(false);
    }

    private void OnSetCameraTarget()
    {
        var player = FindObjectOfType<PlayerManager>().transform;
        virtualCamera.Follow = player;
    }

    private void OnReset()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        virtualCamera.transform.localPosition = _firstPosition;
        virtualCamera.transform.rotation = _firstRotation;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        CoreGameSignals.Instance.onRotateToFaceDown -= RotateToFaceDown;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}