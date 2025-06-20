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

    // colors for each berry stage
    public Color color1;
    public Color color2;
    public Color color3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomTimer1 = Random.Range(2f, 4f);
        randomTimer2 = Random.Range(2f, 6f);
        randomTimer3 = Random.Range(2f, 6f);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increment timer        

        if ((timer > 1f + randomTimer1) && !berrySpawned)
        {
            GetComponent<SpriteRenderer>().color = new Color(color1.r, color1.g, color1.b, 1f); // set berry color
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // initial berry size
            GetComponent<SpriteRenderer>().enabled = true;  // make visible
            berrySpawned = true; // set berry spawned flag to true
        }

        if ((timer > 5f + randomTimer2) && !tick1) // after this time
        {
            GetComponent<SpriteRenderer>().color = new Color(color2.r, color2.g, color2.b, 1f); // change berry color
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // increase berry size
            tick1 = true; // set true so it doesnt run again
        }

        if ((timer > 12f + randomTimer3) && !tick2) // after this time
        {
            GetComponent<SpriteRenderer>().color = new Color(color3.r, color3.g, color3.b, 1f); // change berry color
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); // increase berry size more
            edible = true; // set berry to edible
            tick2 = true; // set true so it doesnt run again
        }

        if (eaten)
        {
            GetComponent<SpriteRenderer>().enabled = false; // deactivate the berry
            GetComponent<SpriteRenderer>().color = new Color(color1.r, color1.g, color1.b, 1f); // reset berry color

            timer = 0f; // reset timer if berry is eaten

            // reset flags
            berrySpawned = false;
            tick1 = false;
            tick2 = false;
            edible = false;
            eaten = false; 

            // reset random timers
            randomTimer1 = Random.Range(2f, 4f);
            randomTimer2 = Random.Range(2f, 6f);
            randomTimer3 = Random.Range(2f, 6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob") && edible)
        {
            // Debug.Log("berry ate"); // test
            eaten = true; // it got eaten

            collision.gameObject.GetComponent<Living>().hunger = 100; // reset hunger
            collision.gameObject.GetComponent<Living>().justAte = true; // set justAte to true
        }
    }
}
