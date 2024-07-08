using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawnCommands 
{
    private readonly GameObject _levelHolder;
    private readonly GameObject _wall;
    private readonly List<GameObject> _platformPrefabs;
    private byte _platformAddition;
    private byte counter=1;
    private readonly GameObject _renk;
    private readonly GameObject _finishline;
    private int lastListIndex = -1;
    private int sameListCount = 0;
    private  int lastPrefabIndex = -1;
    private byte counter1 = 1;

    private readonly List<GameObject> _platformList1;
    private readonly List<GameObject> _platformList2;
    public PlatformSpawnCommands(List<GameObject> platformPrefabs ,GameObject levelHolder, byte platformAddition,GameObject wall, GameObject renk,GameObject finishline, List<GameObject> platformList1, List<GameObject> platformList2)
    {
        _levelHolder = levelHolder;
        _platformPrefabs = platformPrefabs;
        _platformAddition = platformAddition;
        _wall = wall;
        _renk = renk;
        _finishline = finishline;
        _platformList1 = platformList1;
        _platformList2 = platformList2;
    }

    public void Execute(byte currentLevel)
    {
        var resourceRequest = Resources.LoadAsync<GameObject>($"LevelPrefabs/level {0}");
        resourceRequest.completed += operation =>
        {
            var newLevel = Object.Instantiate(resourceRequest.asset.GameObject(),
               new Vector3(0,5.3f,0), Quaternion.identity);
            if (newLevel != null) newLevel.transform.SetParent(_levelHolder.transform);
        };

        if (currentLevel <= 100)
        {
            _platformAddition = 6 * 5;
            for (float i = -4; i > -_platformAddition - (currentLevel) * 8; i -= 8f)
            {
                int prefabIndex = Random.Range(0, 7);
                while (prefabIndex == lastPrefabIndex)
                {
                    prefabIndex = Random.Range(0, 7);
                }

                Vector3 spawnPosition = new Vector3(0f, i, 0f);
                GameObject spawnedPrefab = Object.Instantiate(_platformPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
                spawnedPrefab.transform.SetParent(_levelHolder.transform);

                lastPrefabIndex = prefabIndex;

                _wall.transform.localScale = new Vector3(_wall.transform.localScale.x, -(i * (20)), _wall.transform.localScale.z);

                Vector3 renk1 = new Vector3(0f, i, 0f);
                GameObject renk = Object.Instantiate(_renk, renk1, Quaternion.identity);
                renk.transform.SetParent(_levelHolder.transform);
                counter += 1;
            }
            GameObject spawnedPrefab2 = Object.Instantiate(_finishline, new Vector3(0f, (counter * (-8) + 2), 0f), Quaternion.identity);
            spawnedPrefab2.transform.SetParent(_levelHolder.transform);

            PlatformSpawn();
            counter = 1;
        }
    }

    private void PlatformSpawn()
    {
        float newYPosition = -((counter * 8) + 20);
        for (byte i = 0; i < 70; i++)
        {
            List<GameObject> selectedList = ChooseList();
            GameObject toSpawn = selectedList[Random.Range(0, 3)];
            Vector3 spawnPosition = new Vector3(0f, newYPosition, 0f);
            GameObject numanObj = Object.Instantiate(toSpawn, spawnPosition, Quaternion.identity);
            numanObj.transform.SetParent(_levelHolder.transform);

            TextMeshPro textMesh = numanObj.transform.GetChild(0).GetComponent<TextMeshPro>();
            if (textMesh != null)
            {
                textMesh.text = counter1.ToString();
            }
            counter1++;
            newYPosition -= 9f;
        }
        counter1 = 1;
    }

    private List<GameObject> ChooseList()
    {
        int listIndex = Random.Range(0, 2);
        if (listIndex == lastListIndex)
        {
            sameListCount++;
            if (sameListCount > 2)
            {
                listIndex = 1 - listIndex;
                sameListCount = 1;
            }
        }
        else
        {
            sameListCount = 1;
        }

        lastListIndex = listIndex;
        return listIndex == 0 ? _platformList1 : _platformList2;
    }
}
