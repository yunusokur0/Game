using UnityEngine;

public class LevelDestroyCommand
{
    private readonly GameObject _levelHolder;

    public LevelDestroyCommand(GameObject levelHolder)
    {
        _levelHolder = levelHolder;
    }

    public void Execute()
    {
        foreach (Transform child in _levelHolder.transform)
        {
            Object.Destroy(child.gameObject);
        }
    }
}