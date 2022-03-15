using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSpawner : MonoBehaviour
{
    public float SpawningInterval = 1f;
    public GameObject LampPrefab;

    private void OnEnable() {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawningInterval);
            Instantiate(LampPrefab, transform.position, transform.rotation);
        }
    }
}
