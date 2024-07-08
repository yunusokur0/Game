using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] internal GameObject levelHolder;
    [SerializeField] internal GameObject wall;
    [SerializeField] private List<GameObject> platformPrefabs;
    [SerializeField] private List<GameObject> platformList1;
    [SerializeField] private List<GameObject> platformList2;

    public byte _currentLevel;
    private byte _platformAddition;
    private byte _currentCupValue;
    private PlatformSpawnCommands _platformSpawnCommands;
    private LevelDestroyCommand _levelDestroyCommand;

    public byte level = 0;
    public TextMeshPro text;
    public GameObject renk;
    public GameObject finishline;
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
        _platformSpawnCommands = new PlatformSpawnCommands(platformPrefabs, levelHolder, _platformAddition,wall, renk, finishline, platformList1, platformList2);
        _levelDestroyCommand = new LevelDestroyCommand(levelHolder);
    }

    private void LevelDestroy()
    {
        _levelDestroyCommand.Execute();
    }

    private void OnSetCupText()
    {
        UISignals.Instance.onGetScoreText?.Invoke(1);
        _currentCupValue++;
    }

    private void OnNextLevel()
    {
        _currentLevel++;
        LevelDestroy();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(_currentLevel);
        UISignals.Instance.onGetCupText?.Invoke(_currentCupValue);
        SetLevelText();
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
        CoreGameSignals.Instance.onLevelInitialize += _platformSpawnCommands.Execute;
        CoreGameSignals.Instance.onNextLevel += OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        UISignals.Instance.onSetCupText += OnSetCupText;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize -= _platformSpawnCommands.Execute;
        CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        UISignals.Instance.onSetCupText -= OnSetCupText;
    }
    private void OnDisable() => UnsubscribeEvents();
}