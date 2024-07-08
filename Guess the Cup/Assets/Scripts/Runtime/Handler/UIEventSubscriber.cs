using UnityEngine;
using UnityEngine.UI;

public class UIEventSubscriber : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private UIEventSubscriptionTypes type;
    private UIManager _uiManager;

    private void Awake()
    {
        FindRefernces();
    }
    private void FindRefernces()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.AddListener(_uiManager.OnPlay);
                break;
            case UIEventSubscriptionTypes.OnRestartLevel:
                button.onClick.AddListener(_uiManager.OnRestartLevel);
                break;
        }
    }

    private void UnSubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.AddListener(_uiManager.OnPlay);
                break;
            case UIEventSubscriptionTypes.OnRestartLevel:
                button.onClick.AddListener(_uiManager.OnRestartLevel);
                break;
        }
    }
    private void OnDisable() => UnSubscribeEvents();
}