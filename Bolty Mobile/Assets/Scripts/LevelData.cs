using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int levelUnlocked;

    public LevelData(LevelManager levelManager)
    {
        levelUnlocked = LevelManager.HighestLevelUnlocked;
    }
}
