using UnityEngine;


public class Box : MonoBehaviour
{
    // Rotation speed in degrees per second
    // Adjust this value to change how fast the cube rotates
    [SerializeField] private float rotationSpeed = 80f;
    [SerializeField] private float speedIncrement = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Cube is rotating");
    }

    // Update is called once per frame
    void Update()
    {
        // Check for up arrow keypress to increase rotation speed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotationSpeed += speedIncrement;
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        // Check for down arrow keypress to decrease rotation speed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotationSpeed -= speedIncrement;
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        if (rotationSpeed <= 5f && rotationSpeed >= 300f) 
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        

        // Rotate the object around the y-axis (up vector) at the specified speed
        // Multiply by Time.deltaTime to make the rotation frame-rate independent
        transform.Rotate(0f, 0f, 0f);
    }
}