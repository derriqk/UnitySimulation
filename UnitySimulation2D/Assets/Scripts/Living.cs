using UnityEngine;

public class Living : MonoBehaviour
{
    // this is stats for the organism
    public float health = 100f;
    public float timer = 0f;
    public int thirst = 100; // at thirst 0, slowly decrease health
    public bool alive = true;
    float wait = 1f; // wait for 1 second before destroying the organism
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4f)
        {
            thirst -= 50; // decreast thirst by 10 every 4 seconds
            timer = 0f; // reset the timer
            Debug.Log("thirst: " + thirst); // debug log thirst
        }

        if (thirst <= 0) // checking if dehydrated
        {
            health -= Time.deltaTime * 30f; // lose health over time
            Debug.Log("current health: " + health); // debug log health
        }

        if (health <= 0) // checking if dead
        {
            Debug.Log("blob is dead");
            alive = false;
            GetComponent<SpriteRenderer>().color = Color.red; // change color to red
        }

        if (!alive)
        {
            wait -= Time.deltaTime; // wait for 1 second before destroying the organism
            if (wait <= 0f)
            {
                Destroy(gameObject); // destroy the organism
            }
        }
    }
}
