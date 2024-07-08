using System;
using UnityEngine;
using UnityEngine.UI;


public class UIEventSubscriber : MonoBehaviour
{
    [SerializeField] private UIEventSubscriptionTypes type;
    [SerializeField] private Button button;

    private UIManager _manager;

    private void Awake()
    {
        FindReferences();
    }

    private void FindReferences()
    {
        _manager = FindObjectOfType<UIManager>();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.AddListener(_manager.OnPlay);
                break;

            case UIEventSubscriptionTypes.OnNext:
                button.onClick.AddListener(_manager.OnNextLevel);
                break;

            case UIEventSubscriptionTypes.OnRestart:
                button.onClick.AddListener(_manager.OnRestartLevel);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UnSubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.OnPlay:
                button.onClick.AddListener(_manager.OnPlay);
                break;

            case UIEventSubscriptionTypes.OnNext:
                button.onClick.AddListener(_manager.OnNextLevel);
                break;

            case UIEventSubscriptionTypes.OnRestart:
                button.onClick.AddListener(_manager.OnRestartLevel);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}