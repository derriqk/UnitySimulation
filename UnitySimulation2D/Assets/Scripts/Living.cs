using UnityEngine;

public class Living : MonoBehaviour
{
    // this is stats for the organism
    public int health = 100;
    public bool justDrank = false;
    public bool justAte = false;
    float drinktimer = 0f;
    float eattimer = 0f;
    float healthTimer = 0f; 
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

        // caps
        if (hunger > 100)
        {
            hunger = 100; // cap hunger at 100
        }
        if (thirst > 100)
        {
            thirst = 100; // cap thirst at 100
        }

        if (drinktimer > 2f && !justDrank)
        {
            thirst -= 10; // decreast thirst by 10 
            drinktimer = 0f; // reset the timer

            if (thirst < 0)
            {
                thirst = 0; // cap thirst at 0
            }
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

            if (hunger < 0)
            {
                hunger = 0; // cap hunger at 0
            }
        }
        if (eattimer > 8f)
        {
            justAte = false; // get hungry again after 8 seconds
            eattimer = 0f; // reset the timer
        }

        if (thirst <= 0 || hunger <= 0) // checking if dehydrated or hungry
        {
            healthTimer += Time.deltaTime;
            if (healthTimer > 1f) // every second
            {
                health -= 5;
                healthTimer = 0f; 
            }
            
        }

        if (thirst > 90 || hunger > 90 )
        {
            healthTimer += Time.deltaTime;
            if (healthTimer > 1f) // every second
            {
                health += 3;
                healthTimer = 0f; 
            }

            if (health > 100)
            {
                health = 100; // cap health at 100
            }
        }

        if (health <= 0) // checking if dead
        {
            // Debug.Log("blob is dead");
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
