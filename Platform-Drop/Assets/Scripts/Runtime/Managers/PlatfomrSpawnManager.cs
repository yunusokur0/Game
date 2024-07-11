using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlatfomrSpawnManager : MonoBehaviour
{
    #region
    public GameObject _levelHolder;
    public GameObject _wall;
    public List<GameObject> _numanPrefab;
    public byte counter1 = 1;
    public byte counter2 = 51;
    private float yPos = -459; 

    public GameObject[] _numanPrefab1;
    private int currentListIndex = 0;
    private int listSelectCount = 0;
    public List<GameObject> es = new List<GameObject>();
    public List<GameObject> es1 = new List<GameObject>();
    private List<GameObject>[] lists;


    private bool isCoroutineRunning = false;

    public List<GameObject> pl1;
    public List<GameObject> pl2;
public int lastListIndex;
    public int sameListCount;
    #endregion
    public float ara;

    public GameObject walll;

    private void Start()
    {
        lists = new List<GameObject>[] { es, es1 };
    }
    public void AddToRandomList(GameObject other)
    {
        List<GameObject> selectedList = (Random.Range(0, 2) == 0) ? es : es1;
        selectedList.Add(other);
    }


    private void PlatformSpawn(byte level)
    {
        counter1 = 1;
        var resourceRequest = Resources.LoadAsync<GameObject>($"LevelPrefabs/level {0}");
        resourceRequest.completed += operation =>
        {
            var newLevel = Object.Instantiate(resourceRequest.asset.GameObject(),
               new Vector3(0, 5.3f, 0), Quaternion.identity);
            if (newLevel != null) newLevel.transform.SetParent(_levelHolder.transform);
        };

        for (byte i = 0; i < 200; i++)
        {
            List<GameObject> selectedList = ChooseList();
            GameObject toSpawn = selectedList[Random.Range(0, 3)];
            float newYPosition = -11f - (i * ara); //10.2
            Vector3 spawnPosition = new Vector3(0f, newYPosition, 0f);
            GameObject numanObj = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
            numanObj.transform.SetParent(_levelHolder.transform);

            TextMeshPro textMesh = numanObj.transform.GetChild(0).GetComponent<TextMeshPro>();
            if (textMesh != null)
            {
                textMesh.text = counter1.ToString();
            }
            counter1++;
        }

    }

    private List<GameObject> ChooseList()
    {
        int listIndex = Random.Range(0, 2);
        if (listIndex == lastListIndex)    
        {
            sameListCount++;
            if (sameListCount > 1)
            {
                listIndex = 1 - listIndex; 
                sameListCount = 0;
            }
        }
        else
        {
            sameListCount = 1;
        }

        lastListIndex = listIndex;
        return listIndex == 0 ? pl1 : pl2;
    }
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.ss += AddToRandomList;
        CoreGameSignals.Instance.onLevelInitialize += PlatformSpawn;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.ss -= AddToRandomList;
        CoreGameSignals.Instance.onLevelInitialize -= PlatformSpawn;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
