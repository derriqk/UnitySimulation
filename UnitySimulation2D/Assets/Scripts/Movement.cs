using UnityEngine;

// this script is for the movement of an organism
public class Organism : MonoBehaviour
{
    private float timer = 0f;
    float randomSpeed;
    float randomMoveTime;
    private Living living; // reference to the Living script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        living = GetComponent<Living>(); // get the Living script component
        randomSpeed = Random.Range(1f, 3f); // random speed between 1 and 3
        randomMoveTime = Random.Range(3f, 7f); // move every 3 to 7 seconds at random
    }

    // Update is called once per frame
    void Update()
    {
        // every second timer increments
        timer += Time.deltaTime;

        if (timer > randomMoveTime && living.alive) // only roam once every randomMoveTime seconds, and only move if alive
        {
            StartCoroutine(CoRoam());
            timer = 0f; // reset the timer
        }
    }

    // this is a coroutine that will roam the organism
    private System.Collections.IEnumerator CoRoam()
    {
        Debug.Log("roaming");

        float roamTime = Random.Range(1f, 3f); // roam for random time between 1 and 3 sec

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
        // move the organism to the new position
        transform.position = Vector3.MoveTowards(transform.position, pos, randomSpeed * Time.deltaTime); // move
    }
}
