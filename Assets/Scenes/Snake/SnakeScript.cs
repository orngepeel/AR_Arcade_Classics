using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public float steerSpeed = 180;
    public float snakeSpeed = 1;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.forward * snakeSpeed * Time.deltaTime);


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
}
