using UnityEngine;

public class Living : MonoBehaviour
{
    // this is stats for the organism
    public float health = 100f;
    public float timer = 0f;
    public int thirst = 100; // at thirst 0, slowly decrease health
    public bool alive = true;


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
            health -= Time.deltaTime * 10f; // lose health over time
            Debug.Log("current health: " + health); // debug log health
        }

        if (health <= 0) // checking if dead
        {
            Debug.Log("blob is dead");
            alive = false;
            Destroy(gameObject); // destroy the organism
        }
    }
}
