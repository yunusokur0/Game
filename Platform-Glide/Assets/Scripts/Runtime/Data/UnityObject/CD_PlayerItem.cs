using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_PlayerItem", menuName = "PlatformJump/CD_PlayerItem", order = 0)]
public class CD_PlayerItem: ScriptableObject
{
    public List<PlayerItemData> PlayerObjData;
}