using System.Collections;
using UnityEngine;

public class SpawnCoinBombManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    private float initialSpawnRate = 2.5f;
    private float targetSpawnRate = 0.3f;
    public float currentSpawnRate;
    private float timer = 0;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;

        Debug.Log("Spawnrate reseted");
        StartCoroutine(SpawnObjects()); // Start the coroutine in the Start method
    }

    void Update()
    {
        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(SpawnObjects()); // Start the coroutine when the timer reaches the spawn rate
            timer = 0;
        }

        // Replace Lerp with if-else statement
        if (currentSpawnRate > targetSpawnRate)
        {
            currentSpawnRate -= Time.deltaTime / 180f; // Adjust the decrement rate as needed
        }
        else
        {
            currentSpawnRate = targetSpawnRate;
        }
    }

    IEnumerator SpawnObjects()
    {
        ShuffleObjects(); // Shuffle the array to get a random order

        float[] possibleXPositions = new float[] { -2.1f, -0.7f, 0.7f, 2.1f };
        float randomXPos = possibleXPositions[Random.Range(0, possibleXPositions.Length)];
        Vector3 spawnPosition = new Vector3(randomXPos, transform.position.y, 0f);

        // Check if we spawn the bomb or a regular ball
        GameObject objectToSpawn;
        if (Random.Range(0f, 1f) < 0.1f) // Adjust the probability as needed
        {
            // Spawn the bomb
            objectToSpawn = objectsToSpawn[0];
        }
        else
        {
            // Spawn a regular ball
            objectToSpawn = objectsToSpawn[Random.Range(1, objectsToSpawn.Length)];
        }

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(1f); // Adjust this delay as needed
    }

    void ShuffleObjects()
    {
        // Fisher-Yates shuffle algorithm for shuffling the array
        for (int i = objectsToSpawn.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = objectsToSpawn[i];
            objectsToSpawn[i] = objectsToSpawn[j];
            objectsToSpawn[j] = temp;
        }
    }
}
