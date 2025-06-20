using UnityEngine;

public class WaterSource : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // after being triggered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        {
            //Debug.Log("touched"); // testing
            Living living = collision.gameObject.GetComponent<Living>();
            if (living.alive) // check alive
            {
                living.thirst = 100; // reset thirst to 100
                //Debug.Log("drank");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        {
            //Debug.Log("touched"); // testing
            Living living = collision.gameObject.GetComponent<Living>();
            if (living.alive) // check alive
            {
                // Debug.Log("drinking");
                living.thirst = 100; // thirst keeps at 100 when staying in water
                living.justDrank = true; // set justDrank to true
            }
        }
    }

    
        
}
