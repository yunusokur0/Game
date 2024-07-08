using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class PlayerMovementController : MonoBehaviour
{
    public float forwardSpeed;
    private Rigidbody _rigidbody;
    private bool _isGameReady;
    private bool _isFirstMove = true;
    private float _timer;

    public TextMeshProUGUI gerisa;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isGameReady)
        {
            Move();
        }
    }
    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound4, true);
        gerisa.text = 3.ToString();
        gerisa.DOColor(Color.red,0);
        yield return new WaitForSeconds(.5f); // 1 saniye bekler
        SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound4, true);
        gerisa.text = 2.ToString();
        Color orange = new Color(1f, 0.64f, 0f, 1f); // R: 255, G: 165, B: 0
        gerisa.DOColor(orange, 0);
        yield return new WaitForSeconds(.5f); // 1 saniye daha bekler
        SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound4, true);
        gerisa.text = 1.ToString();
        gerisa.DOColor(Color.green, 0);
        yield return new WaitForSeconds(.5f); // Son 1 saniye bekler
        Destroy(gerisa);
        forwardSpeed = 10;
        SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound2, true);
    }
    private void Move()
    {
        if (_isFirstMove)
        {
            _rigidbody.isKinematic = false;
            _isFirstMove = false;
        }

        Vector3 downwardMovement = Vector3.down * forwardSpeed;
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, downwardMovement.y, _rigidbody.velocity.z);

        ManageSpeedIncrease();
    }

    private void ManageSpeedIncrease()
    {
        _timer += Time.deltaTime;

        if (forwardSpeed >= 10 && forwardSpeed <= 20 && _timer >= 0.2f)
        {
            IncreaseSpeed(0.22f, ref _timer);
        }

        else if (forwardSpeed >= 20 && forwardSpeed <= 25 && _timer >= .2f)
        {
            IncreaseSpeed(.05f, ref _timer);
        }

        //else if (forwardSpeed >= 25 && forwardSpeed <= 27 && _timer >= .2f)
        //{
        //    IncreaseSpeed(.003f, ref _timer);
        //}
    }

    private void IncreaseSpeed(float amount, ref float timer)
    {
        forwardSpeed += amount;
        timer = 0f;
    }

    public void OnPlayConditionChanged(bool condition)
    {
        _rigidbody.isKinematic = !condition;
        _isGameReady = condition;
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged += OnPlayConditionChanged;
        PlayerSignals.Instance.asdasd += StartCountdown;

    }

    private void UnSubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged -= OnPlayConditionChanged;
        PlayerSignals.Instance.asdasd -= StartCountdown;
    }
    private void OnDisable() => UnSubscribeEvents();
}