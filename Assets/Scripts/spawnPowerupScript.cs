using System.Collections;
using UnityEngine;

public class SpawnPoweupManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    private float minSpawnRate = 1f;
    private float maxSpawnRate = 5f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float randomSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(randomSpawnRate);

            ShuffleObjects();

            float[] possibleXPositions = new float[] { -2.1f, -0.7f, 0.7f, 2.1f };
            float randomXPos = possibleXPositions[Random.Range(0, possibleXPositions.Length)];
            Vector3 spawnPosition = new Vector3(randomXPos, transform.position.y, 0f);

            Instantiate(objectsToSpawn[0], spawnPosition, Quaternion.identity);
        }
    }

    void ShuffleObjects()
    {
        for (int i = objectsToSpawn.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = objectsToSpawn[i];
            objectsToSpawn[i] = objectsToSpawn[j];
            objectsToSpawn[j] = temp;
        }
    }
}
