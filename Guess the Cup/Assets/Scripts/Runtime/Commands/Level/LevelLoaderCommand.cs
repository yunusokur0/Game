using Unity.VisualScripting;
using UnityEngine;

public class LevelLoaderCommand
{
    private readonly LevelManager _levelManager;

    public LevelLoaderCommand(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }

    public void Execute(byte parameter)
    {
        var resourceRequest = Resources.LoadAsync<GameObject>($"LevelPrefabs/level {parameter}");
        resourceRequest.completed += operation =>
        {
            Vector3 nm = new Vector3(0,0,6.5f);
            var newLevel = Object.Instantiate(resourceRequest.asset.GameObject(),
                nm, Quaternion.identity);
            if (newLevel != null) newLevel.transform.SetParent(_levelManager.levelHolder.transform);
        };
    }
}