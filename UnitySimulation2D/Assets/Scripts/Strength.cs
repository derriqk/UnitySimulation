using UnityEngine;

public class Strength : MonoBehaviour
{
    public int strength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strength = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob") && collision.gameObject != gameObject)
        {
            // get references
            Strength otherStrength = collision.gameObject.GetComponent<Strength>();
            Living otherLiving = collision.gameObject.GetComponent<Living>();
            Living thisLiving = GetComponent<Living>();

            if (otherLiving.alive && thisLiving.alive)
            {
                if (strength > otherStrength.strength)
                {
                    // Debug.Log("strong");
                    thisLiving.justAte = true; // eat the other blob
                    otherLiving.health -= 100;

                    // steal stats
                    thisLiving.hunger += 25;
                    thisLiving.thirst += 15;
                    strength += otherStrength.strength;

                    // increase size
                    Vector3 newScale = transform.localScale * 1.05f; // increase size by 5%
                    transform.localScale = newScale;
                }
            }
        }
    } 
}
