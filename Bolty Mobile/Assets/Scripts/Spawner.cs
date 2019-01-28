using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] boltPrefabArray;
    public int projectileCount = 10;
    BoltCounter boltCounter;


    // Use this for initialization
    void Start () {
        boltCounter = FindObjectOfType<BoltCounter>();

    }
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in boltPrefabArray)
        {
            if(isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}
    bool isTimeToSpawn (GameObject boltGameObject)
    {
        Bolt bolt = boltGameObject.GetComponent<Bolt>();

        float meanSpawnDelay = bolt.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (projectileCount<= 0)
        {
            return false;
        }
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
      
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myBolt = Instantiate(myGameObject) as GameObject;
        myBolt.transform.parent = transform;
        myBolt.transform.position = transform.position;
        projectileCount -= 1;
        boltCounter.UpdateCounter();
    }
}
