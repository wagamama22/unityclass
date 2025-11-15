using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;

    [SerializeField] float minimumTimeBetweenShots = 0.2f;
    [SerializeField] float maximumTimeBetweenShots = 3f;
    [SerializeField] float shotCounter ;

    private void OnTriggerEnter2D(Collider2D collision)//built in method because color is blue and will trigger the code inside
        //collission saves all the properties of the object that touched it. here you can efeect change in both the object that
        //touch or the one it touches. yellow color reps the method u created
    {
        DamageDealer dd = collision.gameObject.GetComponent<DamageDealer>();
        health -= dd.GetDamage();
        if (health <= 0) 
        {
            Destroy(gameObject); //enemy dies
            dd.Hit(); //destroy the damage dealer object
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //initialize shot counter with a random value between min and max time between shots
        shotCounter = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
    }
}
