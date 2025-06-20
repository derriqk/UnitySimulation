using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject radius;
    public GameObject blob;
    float[] width = new float[2];
    float[] height = new float[2];
    Bounds bounds;
    float timer = 0f;
    float rate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bounds = radius.GetComponent<Renderer>().bounds;
        width[0] = bounds.min.x;
        width[1] = bounds.max.x;
        height[0] = bounds.min.y;
        height[1] = bounds.max.y;

        rate = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f + rate)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(width[0], width[1]), Random.Range(height[0], height[1]), 0f);
            GameObject newObject = Instantiate(blob, spawnPosition, Quaternion.identity);
            rate = Random.Range(1f, 5f); // randomize again
            timer = 0f; // reset timer
        }
    }
}
