using UnityEngine;

public class BerryScript : MonoBehaviour
{
    float timer = 0f; // timer for berry spawning
    bool berrySpawned = false; // spawned berry flag
    bool eaten = false;
    bool edible = false;
    bool tick1 = false;
    bool tick2 = false;

    // random timer for the berry
    float randomTimer1;
    float randomTimer2;
    float randomTimer3;
    
    private Color originalColor; // to store the original color of the berry

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        randomTimer1 = Random.Range(2f, 4f);
        randomTimer2 = Random.Range(2f, 6f);
        randomTimer3 = Random.Range(2f, 6f);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increment timer        

        if ((timer > 1f + randomTimer1 ) && !berrySpawned)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // initial berry size
            GetComponent<SpriteRenderer>().enabled = true;  // make visible
            berrySpawned = true; // set berry spawned flag to true
        }

        if ((timer > 5f + randomTimer2 ) && !tick1) // after this time
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f); // change berry color to red
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // increase berry size
            tick1 = true; // set true so it doesnt run again
        }

        if ((timer > 12f + randomTimer3) && !tick2) // after this time
        {
            GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.2f, 0.2f); // change berry color to darker red
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); // increase berry size more
            edible = true; // set berry to edible
            tick2 = true; // set true so it doesnt run again
        }

        if (eaten)
        {
            GetComponent<SpriteRenderer>().enabled = false; // deactivate the berry
            GetComponent<SpriteRenderer>().color = originalColor; // original color
            timer = 0f; // reset timer if berry is eaten

            // reset flags
            berrySpawned = false;
            tick1 = false;
            tick2 = false;
            edible = false;
            
            // reset random timers
            randomTimer1 = Random.Range(2f, 4f);
            randomTimer2 = Random.Range(2f, 6f);
            randomTimer3 = Random.Range(2f, 6f);
        }
    }
}
