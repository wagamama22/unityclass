using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Movement speed
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
        Vector2 movement = new Vector2(moveX, moveY)* speed * Time.deltaTime;

        // Apply the movement to the player 's transform'
        transform.Translate(movement);
    }

    // Update is called once per frame

    void Update()
    {
       // call the move method
       Move();
    }
}
