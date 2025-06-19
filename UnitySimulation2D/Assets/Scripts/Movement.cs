using UnityEngine;

// this script is for the movement of an organism
public class Organism : MonoBehaviour
{
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // every second timer increments
        timer += Time.deltaTime;

        if (timer > 5f) // only roam after 5 seconds pass
        {
            StartCoroutine(CoRoam());
            timer = 0f; // reset the timer
        }
    }

    // this is a coroutine that will roam the organism
    private System.Collections.IEnumerator CoRoam()
    {
        Debug.Log("roaming");

        float roamTime = 3f;

        // map max coords, used for random
        int[] max_X = { -8, 8 };
        int[] max_Y = { -4, 4 };

        float randomX = Random.Range(max_X[0], max_X[1]);
        float randomY = Random.Range(max_Y[0], max_Y[1]);

        while (roamTime > 0f)
        {
            Roam(new Vector3(randomX, randomY, 0f));
            roamTime -= Time.deltaTime; // decrement the roam time
            yield return null; // wait for the next frame
        }
    }

    void Roam(Vector3 pos)
    {
        // move the organism to the new position over 3 sec
        transform.position = Vector3.MoveTowards(transform.position, pos, 3f * Time.deltaTime); // move in 3 seconds
    }
}
