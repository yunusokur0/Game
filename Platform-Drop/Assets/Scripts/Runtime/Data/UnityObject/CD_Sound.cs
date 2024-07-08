using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_Sound", menuName = "PlatformJump/CD_Sound", order = 0)]
public class CD_Sound : ScriptableObject
{
    public List<SoundData> SoundData; 
}