using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
    public float steerSpeed = 180;
    public float snakeSpeed = 1;
    public Vector3 startPosition;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject upButton;
    public GameObject downButton;

    private string currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        setDirection("up");
    }

    // Update is called once per frame
    void Update()
    {
        changeDirection(currentDirection);

    }

    void Grow() 
    {

    }

    void ResetState()
    {
        transform.position = startPosition;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food")) {
            Grow();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            ResetState();
        }
    }

    public void setDirection(string direction)
    {
        currentDirection = direction;

        // add logic for rotating snake head prefab here
    }

    private void changeDirection(string direction)
    {
        // if up
        if(direction == "up")
        {
            transform.position = transform.position + (transform.forward * snakeSpeed * Time.deltaTime);
        }

        // if down
        if(direction == "down")
        {
            transform.position = transform.position + (-transform.forward * snakeSpeed * Time.deltaTime);
        }

        // if right
        if(direction == "right")
        {
            transform.position = transform.position + (transform.right * snakeSpeed * Time.deltaTime);
        }

        // if left
        if(direction == "left")
        {
            transform.position = transform.position + (-transform.right * snakeSpeed * Time.deltaTime);
        }
    }
}
