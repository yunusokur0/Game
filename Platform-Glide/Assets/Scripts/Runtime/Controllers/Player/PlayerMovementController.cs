using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private new Rigidbody rigidbody;

    public bool _isGameReadyy;
    private bool oldu = true;

    public bool yes = false;
    private float _timer;

    private void FixedUpdate()
    {
        if (_isGameReadyy)
        {
            Move();
        }
    }

    private void Move()
    {
        if (oldu)
        {
            rigidbody.isKinematic = false;
            oldu = false;
        }
        Vector3 downwardMovement = Vector3.down * forwardSpeed;
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, downwardMovement.y, GetComponent<Rigidbody>().velocity.z);

        if (yes == true)
        {
            ManageSpeedIncrease();
        }
    }

    private void ManageSpeedIncrease()
    {
        _timer += Time.deltaTime;

        if (forwardSpeed < 6)
        {
            forwardSpeed = 18;
        }

        else if (forwardSpeed <= 30 && _timer >= .2f)
        {
            forwardSpeed += .2f;
            _timer = 0f;
        }
    }

    private void OnPlayConditionChanged(bool condition)
    {
        rigidbody.isKinematic = !condition;
        _isGameReadyy = condition;
    }

    public void degdi()
    {
        yes = true;
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged += OnPlayConditionChanged;
    }

    private void UnSubscribeEvents()
    {
        PlayerSignals.Instance.onPlayConditionChanged -= OnPlayConditionChanged;
    }
    private void OnDisable() => UnSubscribeEvents();
}