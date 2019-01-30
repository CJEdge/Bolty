using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int projectileCount;
    BoltCounter boltCounter;
    public bool spawn = true;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;
    [SerializeField] Bolt boltPrefab;

   
   
    IEnumerator Start()
    {
        boltCounter = FindObjectOfType<BoltCounter>();
        while (projectileCount > 0 && spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    void Spawn()
    {
        {
            Instantiate(boltPrefab, transform.position, transform.rotation);
            projectileCount -= 1;
            boltCounter.UpdateCounter();
        }
    }
    
}
