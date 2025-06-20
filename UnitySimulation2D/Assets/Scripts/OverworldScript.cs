using UnityEngine;

public class OverWorldRule : MonoBehaviour
{
    public GameObject blobPrefab;
    int[] max_X = { -8, 8 };
    int[] max_Y = { -4, 4 };
    float timer = 0f;
    float randomInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomInterval = Random.Range(1f, 5f); // random interval for spawning blobs
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 + randomInterval) // every 1 + randomInterval seconds, spawn a blob
        {
            Vector3 newSpawn = new Vector3(Random.Range(max_X[0], max_X[1]), Random.Range(max_Y[0], max_Y[1]), 0);
            Instantiate(blobPrefab, newSpawn, Quaternion.identity); // create blob at that spot
            timer = 0f; // reset the timer
        }
    }
}
