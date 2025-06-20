using UnityEngine;

public class Living : MonoBehaviour
{
    // this is stats for the organism
    public float health = 100f;
    public bool justDrank = false;
    public bool justAte = false;
    float drinktimer = 0f;
    float eattimer = 0f;
    public int thirst = 100; // at thirst 0, slowly decrease health
    public bool alive = true;
    public int hunger = 100;
    float wait = 1f; // wait for 1 second before destroying the organism
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drinktimer += Time.deltaTime;
        eattimer += Time.deltaTime;
        if (drinktimer > 2f && !justDrank)
        {
            thirst -= 10; // decreast thirst by 10 
            drinktimer = 0f; // reset the timer
            // Debug.Log("thirst: " + thirst); // debug log thirst
        }
        if (drinktimer > 5f)
        {
            justDrank = false; // get thirsty again after 5 seconds
            drinktimer = 0f; // reset the timer
        }

        if (eattimer > 3f && !justAte)
        {
            hunger -= 10; // decrease hunger by 10 
            eattimer = 0f; // reset the timer
        }
        if (eattimer > 8f)
        {
            justAte = false; // get hungry again after 8 seconds
            eattimer = 0f; // reset the timer
        }

        if (thirst <= 0 || hunger <= 0) // checking if dehydrated or hungry
        {
            health -= Time.deltaTime * 30f; // lose health over time
        }

        if (thirst > 90 || hunger > 90 )
        {
            health += Time.deltaTime * 10f; // gain health over time
            if (health > 100f)
            {
                health = 100f; // cap health at 100
            }
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
