using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] internal GameObject levelHolder;

    private LevelLoaderCommand _levelLoader;
    private LevelDestroyerCommand _levelDestroyer;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(1);
    }

    private void Init()
    {
        _levelLoader = new LevelLoaderCommand(this);
        _levelDestroyer = new LevelDestroyerCommand(this);
    }


    private void OnRestartLevel()
    {
        CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(1);
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize += _levelLoader.Execute;
        CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyer.Execute;
        CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize -= _levelLoader.Execute;
        CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyer.Execute;
        CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
    }
    private void OnDisable() => UnsubscribeEvents();
}