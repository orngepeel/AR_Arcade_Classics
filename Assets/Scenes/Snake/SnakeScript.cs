using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
    public float steerSpeed = 180;
    public float snakeSpeed = 1;
    public Vector3 startPosition;

    // these DO rotate the snake head, but they don't do it level to the plane of the board? I tried all three axes
    public Vector3 upRotate = new Vector3(0, 0, 0);
    public Vector3 downRotate = new Vector3(0, 0, 180);
    public Vector3 rightRotate = new Vector3(0, 0, 90);
    public Vector3 leftRotate = new Vector3(0, 0, -90);

    string currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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

        // add logic for rotating snake head prefab here, since it will only get called on button press

    }

    private void changeDirection(string direction)
    {
        // if up
        if(direction == "up")
        {
            //transform.eulerAngles = upRotate;
            transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
        }

        // if down
        else if(direction == "down")
        {
            //transform.eulerAngles = downRotate;
            transform.Translate(-Vector3.forward * snakeSpeed * Time.deltaTime);
        }

        // if right
        else if(direction == "right")
        {
            //transform.eulerAngles = rightRotate;
            transform.Translate(Vector3.right * snakeSpeed * Time.deltaTime);
        }

        // if left
        else if(direction == "left")
        {
            //transform.eulerAngles = leftRotate;
            transform.Translate(-Vector3.right * snakeSpeed * Time.deltaTime);
        }
    }
}
