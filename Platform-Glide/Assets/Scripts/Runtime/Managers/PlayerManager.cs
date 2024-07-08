using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject cupcake;
    private byte _stageValue;

    private CD_PlayerItem item;
    public GameObject player;

    private void Awake()
    {
        item = GetCD_Sound();
    }

    private CD_PlayerItem GetCD_Sound() => Resources.Load<CD_PlayerItem>("Data/CD_PlayerItem");
    private void nnn(int ii)
    {
        Destroy(player);
        GameObject instance = Instantiate(item.PlayerObjData[ii].PlayerPrefabs, new Vector3(0, 4.81f, 0), Quaternion.identity, gameObject.transform);
        instance.SetActive(true);
        player = instance;
    }



    private void OnStageAreaSuccessful()
    {
        if (_stageValue <= 4)
        {
            UISignals.Instance.onSetStageColor?.Invoke(_stageValue);
            cupcake.SetActive(_stageValue == 4);
            _stageValue++;
        }
    }

    private void OnPlay()
    {
        PlayerSignals.Instance.onPlayConditionChanged?.Invoke(true);
    }

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputTaken += () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(true);
        InputSignals.Instance.onInputReleased += () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(false);
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.nnn += nnn;
        CoreGameSignals.Instance.onStageAreaSuccessful += OnStageAreaSuccessful;
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputTaken -= () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(true);
        InputSignals.Instance.onInputReleased -= () => PlayerSignals.Instance.onMoveConditionChanged?.Invoke(false);
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.nnn -= nnn;
        CoreGameSignals.Instance.onStageAreaSuccessful -= OnStageAreaSuccessful;
    }
    private void OnDisable() => UnSubscribeEvents();
}