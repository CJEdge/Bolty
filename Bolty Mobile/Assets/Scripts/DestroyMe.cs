using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(waitToDestroy());
    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
