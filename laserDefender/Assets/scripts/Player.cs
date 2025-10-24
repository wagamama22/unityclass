using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Movement speed
    private Vector2 movement;
    [Header("Screen hard coded Bounds")]
    [SerializeField] private float minX = -4.43f;
    [SerializeField] private float maxX = 4.32f;
    [SerializeField] private float minY = -8.47f;
    [SerializeField] private float maxY = 8.52f;

    [SerializeField] GameObject laserPrefab;//specified we need a laser prefab

    //create a variable of coroutine of type ienumerator
    IEnumerator shootingCoroutine;

    float extraY = 0.45f;
    Vector2 playerPosition;

    // Get the main camera/ declaring the camera variable
    Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        //save the couroutine inside this variable
        shootingCoroutine = ShootContinuosly();

        //write a method that makes the player move on the x and y axis using the arrow keys and the unity old input system
        //update the code so that the player ship uses screen wrapping
    }
    //create method for screen boundaries with hard coded and not dynamic
    void screenoundaryHardCode() 
    {
       
        //screen wrapping for bounds
        Vector3 newPosition = transform.position;

        //boundaries for x-axis
        if (newPosition.x > maxX)//newPosition.x and .y means the current position of the player in the screen
        {
            newPosition.x = maxX;
        }
        else if (newPosition.x < minX)
        {
            newPosition.x = minX;
        }
        //boundaries for y-axis
        if (newPosition.y > maxY)
        {
            newPosition.y = maxY;
        }
        else if (newPosition.y < minY)
        {
            newPosition.y = minY;
        }
        transform.position = newPosition;//sets the position to newPosition
    }

    //create method for screen-wrapping
    private void WrapPlayer()

    {
        // Convert screen coordinates to world coordinates
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        // Check horizontal wrapping

        if (viewportPosition.x > 1f)

        {

            viewportPosition.x = 0f;

        }

        else if (viewportPosition.x < 0f)

        {

            viewportPosition.x = 1f;

        }



        // Check vertical wrapping

        if (viewportPosition.y > 1f)

        {

            viewportPosition.y = 0f;

        }

        else if (viewportPosition.y < 0f)

        {

            viewportPosition.y = 1f;

        }
        // Convert back to world coordinates and apply

        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);

    }



    //create the move method
    void Move()
    {
        // Get input from arrow keys
        float moveX = Input.GetAxis("Horizontal"); // Left/Right arrows
        float moveY = Input.GetAxis("Vertical");   // Up/Down arrows

        // Create movement vector
        Vector2 movement = new Vector2(moveX, moveY) * speed * Time.deltaTime;

        // Apply the movement to the player 's transform'
       
        transform.Translate(movement);//transform has to do with position of gameobject while translate renders the transform action.
        
    }

    void ShootLaser() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shootingCoroutine);
        }

        if(Input.GetButtonUp("Fire1")) 
        {
            StopCoroutine(shootingCoroutine);
        }
    }   

    //create coroutine
    IEnumerator ShootContinuosly() 
    {
        while (true)//loop untill we stop the coroutine 
        {
            playerPosition = transform.position;//saving the position of the player in a variable
            playerPosition.y += extraY;//shhot from the tip
            //instantiate the laser prefab at the player position wit no rotation
            GameObject laser = Instantiate(laserPrefab, playerPosition, Quaternion.identity); //save to a variable of gameobject
            laser.GetComponent<Rigidbody2D>().linearVelocityY = 10f;

            //wait for o.2 seconds before shooting again
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame

    void Update()
    {
       // call the move method
       Move();
       //screenoundaryHardCode();
       WrapPlayer();
       ShootLaser();
        
    }
}
