using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] pickupSpawns;
    public GameObject[] enemySpawns;

    public float pickupTimer = 20f;
    public float enemyTimer = 7f;

    public float yPositionRange = 4.5f;

    Coroutine pickupSpawner;
    Coroutine enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        pickupSpawner = StartCoroutine(SpawnInterval(pickupSpawns, pickupTimer));
        enemySpawner = StartCoroutine(SpawnInterval(enemySpawns, enemyTimer));
    }

    IEnumerator SpawnInterval(GameObject[] spawnableObjects, float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            GameObject spawnedObject = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)]);
            spawnedObject.transform.position = new Vector2(transform.position.x, Random.Range(-yPositionRange, yPositionRange));
        }
    }
}
