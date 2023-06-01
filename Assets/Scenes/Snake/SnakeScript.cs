using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
    public float steerSpeed = 180;
    public float snakeSpeed = 1;
    public Vector3 startPosition;
    public List<Transform> _segments;
    public Transform segmentPrefab;
    public int initialSize = 4;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;

    // these DO rotate the snake head, but they don't do it level to the plane of the board? I tried all three axes
    public Vector3 upRotate = new Vector3(0, 0, 0);
    public Vector3 downRotate = new Vector3(0, 0, 180);
    public Vector3 rightRotate = new Vector3(0, 0, 90);
    public Vector3 leftRotate = new Vector3(0, 0, -90);

    string currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        changeDirection(currentDirection);

        for (int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }

    }

    void Grow() 
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    void ResetState()
    {
        transform.position = startPosition;

        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++) {
            Grow();
    }

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
        if(direction == "up")
        {
            transform.LookAt(upWall.transform);
        }

        // if down
        else if(direction == "down")
        {
            transform.LookAt(downWall.transform);
        }

        // if right
        else if(direction == "right")
        {
            transform.LookAt(rightWall.transform);
        }

        // if left
        else if(direction == "left")
        {
            transform.LookAt(leftWall.transform);
        }

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
