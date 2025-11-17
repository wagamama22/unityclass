using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;

    [SerializeField] float minimumTimeBetweenShots = 0.2f;
    [SerializeField] float maximumTimeBetweenShots = 3f;
    [SerializeField] float shotCounter ;
    [SerializeField] GameObject laserPrefab;

    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField][Range(0, 1)] float enemyDeathSoundVolume = 0.7f;

    [SerializeField] AudioClip enemyShootSound;
    [SerializeField][Range(0, 1)] float enemyShootSoundVolume = 0.25f;




    private void OnTriggerEnter2D(Collider2D collision)//built in method because color is blue and will trigger the code inside
        //collission saves all the properties of the object that touched it. here you can efeect change in both the object that
        //touch or the one it touches. yellow color reps the method u created
    {
        DamageDealer dd = collision.gameObject.GetComponent<DamageDealer>();
        health -= dd.GetDamage();
        dd.Hit(); //destroy the damage dealer object

        if (health <= 0) 
        {
            Destroy(gameObject); //enemy dies
            //play death sound
            AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);


        }

    }

    void CountDownAndShoot() 
    {
        //count down the shot counter avery frame
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f) 
        {
            //shoot
            EnemyFire();
            //reset the shot counter with a random value between min and max time
            shotCounter = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
        }
    }

    void EnemyFire() 
    {
        //instantiate the laser prefab at the enemy position wit no rotation
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity); //save to a variable of gameobject
        laser.GetComponent<Rigidbody2D>().linearVelocityY = -5f;

        //play shooting sound
        AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, enemyShootSoundVolume);

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
}
