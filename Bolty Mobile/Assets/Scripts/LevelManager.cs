using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelDisplayText;
    public static int HighestLevelUnlocked = 3;

    public void Start()
    {
        HighestLevelUnlocked = 3;
    }


    public void Update()
    {
        levelDisplayText.text = HighestLevelUnlocked.ToString();
    }
    public void LoadLevel(int level)
    {
        if (level <= HighestLevelUnlocked)
        {
            SceneManager.LoadScene(level);
        }
    }
    public void QuitRequest()
    {
        Application.Quit();
    }
    public void RevertLevelProgress()
    {
        HighestLevelUnlocked = 3;
        SaveLevelUnlock();
        LoadLevelUnlock();
    }

    public void SaveLevelUnlock()
    {
        SaveSystem.SaveLevelUnlocked(this);
    }
   
    public void LoadLevelUnlock()
    {
        LevelData data = SaveSystem.LoadLevelUnlocked();
        HighestLevelUnlocked = data.levelUnlocked;
    }
    public void TutorialLevelFailed()
    {
        HighestLevelUnlocked -= 1;
    }
    public void UnlockNextLevel()
    {
        HighestLevelUnlocked += 1;
    }
    public void LoadHighestLevel()
    {

       SceneManager.LoadScene(HighestLevelUnlocked);
    }
}
