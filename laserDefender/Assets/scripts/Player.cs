using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Movement speed
    private Vector2 movement;
    [Header("Screen Wrap Bounds")]
    [SerializeField] private float minX = -4.43f;
    [SerializeField] private float maxX = 4.32f;
    [SerializeField] private float minY = -8.47f;
    [SerializeField] private float maxY = 8.52f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //write a method that makes the player move on the x and y axis using the arrow keys and the unity old input system
        //update the code so that the player ship uses screen wrapping
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
        transform .position = newPosition;//sets the position to newPosition
    }

    // Update is called once per frame

    void Update()
    {
       // call the move method
       Move();
    }
}
