using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] internal GameObject levelHolder;
    public byte _currentLevel;
    private byte _currentCupValue;
    private LevelDestroyCommand _levelDestroyCommand;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(_currentLevel);
        SetLevelText();
    }

    private void Init()
    {
        _levelDestroyCommand = new LevelDestroyCommand(levelHolder);
    }

    private void LevelDestroy()
    {
        _levelDestroyCommand.Execute();
    }

    private void OnNextLevel()
    {
        LevelDestroy();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(_currentLevel);
        UISignals.Instance.onGetCupText?.Invoke(_currentCupValue);
    }

    private void OnRestartLevel()
    {
        LevelDestroy();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(_currentLevel);
        SetLevelText();
    }

    private void SetLevelText()
    {
        UISignals.Instance.onSetLevelText?.Invoke(_currentLevel);
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onNextLevel += OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
    }
    private void OnDisable() => UnsubscribeEvents();
}