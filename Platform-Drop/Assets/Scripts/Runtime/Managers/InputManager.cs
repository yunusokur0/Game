using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public bool isReadyForTouch, isFirstTimeTouchTaken, _isTouching;
    public bool nm;

    private void Update()
    {
        if (!isReadyForTouch) return;

        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement())
        {
            SoundSignals.Instance.onGetTriggerSound?.Invoke(SoundType.TriggerSound1, false);
            nm = !nm;
            PlayerSignals.Instance.onMoveConditionChanged?.Invoke(nm);
        }
    }

    private bool IsPointerOverUIElement()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void OnPlay()
    {
        isReadyForTouch = true;
    }

    private void OnReset()
    {
        _isTouching = false;
        isReadyForTouch = false;
        isFirstTimeTouchTaken = false;
    }
    private void OnMoveConditionChanged(bool condition) => nm = condition;
    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onReset += OnReset;
        CoreGameSignals.Instance.sff += OnMoveConditionChanged;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onReset -= OnReset;
        CoreGameSignals.Instance.sff -= OnMoveConditionChanged;
    }
    private void OnDisable() => UnsubscribeEvents();
}