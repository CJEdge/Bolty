using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoltCounter : MonoBehaviour
{
    private Text boltCounterText;
    public Spawner[] projectileSpawners;
    public int totalProjectiles;
    public GameObject fPlatform;
    public GameObject directionalArrow;
    public GameObject levelComplete;

    void Start()
    {
        levelComplete.SetActive(false);
        fPlatform.SetActive(false);
        boltCounterText = GetComponent<Text>();
        projectileSpawners = FindObjectsOfType<Spawner>();
        directionalArrow.SetActive(false);

        foreach (Spawner projectileSpawner in projectileSpawners)
        {
            totalProjectiles += projectileSpawner.projectileCount;
        }
        boltCounterText.text = totalProjectiles.ToString();
    }

    void Update()
    {
        if (totalProjectiles == 0)
        {
            fPlatform.SetActive(true);
        }
    }

    public void UpdateCounter()
    {

        totalProjectiles -= 1;
        boltCounterText.text = totalProjectiles.ToString();

    }
    public void LevelComplete()
        { 
        levelComplete.SetActive(true);
        }
}
