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
        //es.Clear();
        //es1.Clear();
        counter1 = 1;
        //counter2 = 51;
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

        //SpawnNumanObjects();
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

    //void SpawnNumanObjects()

    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        for(int j = 0; j<4; j++)
    //        {
    //            GameObject numanObj;
    //            numanObj = Instantiate(pl1[Random.Range(0, 3)]);
    //            numanObj.SetActive(false);
    //            numanObj.transform.SetParent(_levelHolder.transform);
    //            es.Add(numanObj);
    //        }

    //    }

    //    for (int i = 0; i < 3; i++) 
    //    {
    //        for (int j = 0; j < 4; j++)
    //        {
    //            GameObject numanObj;
    //            numanObj = Instantiate(pl2[Random.Range(0, 3)]);
    //            numanObj.SetActive(false);
    //            numanObj.transform.SetParent(_levelHolder.transform);
    //            es1.Add(numanObj);
    //        }

    //    }

    //    for (int j = 0; j < 3; j++)
    //    {
    //        GameObject numanObj;
    //        numanObj = Instantiate(pl2[Random.Range(3, 4)]);
    //        numanObj.SetActive(false);
    //        numanObj.transform.SetParent(_levelHolder.transform);
    //        es1.Add(numanObj);
    //    }

    //    for (int j = 0; j < 1; j++)
    //    {
    //        GameObject numanObj;
    //        numanObj = Instantiate(pl2[Random.Range(4, 5)]);
    //        numanObj.SetActive(false);
    //        numanObj.transform.SetParent(_levelHolder.transform);
    //        es.Add(numanObj);
    //    }
    //}
   
    //private void Update()
    //{
    //    if (es.Exists(obj => !obj.activeSelf) && !isCoroutineRunning && es.Count > 10)
    //    {
    //        StartCoroutine(ActivateAndMoveDown());
    //        isCoroutineRunning = true;
    //    }
    //}

    //IEnumerator ActivateAndMoveDown()
    //{
    //    isCoroutineRunning = true;
    //    while (es.Count > 0 || es1.Count > 0) 
    //    {
    //        List<GameObject> deactiveChildren = lists[currentListIndex].FindAll(child => !child.activeSelf);

    //        if (deactiveChildren.Count == 0)
    //        {
    //            currentListIndex = 1 - currentListIndex;
    //            listSelectCount = 0;
    //            continue;
    //        }

    //        int randomIndex = Random.Range(0, deactiveChildren.Count);
    //        GameObject childToActivate = deactiveChildren[randomIndex];
    //        childToActivate.SetActive(true);

    //        childToActivate.transform.position = new Vector3(
    //            childToActivate.transform.position.x,
    //            yPos,
    //            childToActivate.transform.position.z
    //        );

    //        yPos -= 9f;

    //        TextMeshPro textMesh = childToActivate.GetComponentInChildren<TextMeshPro>();
    //        if (textMesh != null)
    //        {
    //            textMesh.text = counter2.ToString();
    //        }

    //        lists[currentListIndex].Remove(childToActivate);

    //        listSelectCount++;
    //        if (listSelectCount >= 2)
    //        {
    //            currentListIndex = 1 - currentListIndex; 
    //            listSelectCount = 0;
    //        }

    //        yield return new WaitForSeconds(0.5f);
    //        counter2++;
    //    }
    //    isCoroutineRunning = false;
    //}

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