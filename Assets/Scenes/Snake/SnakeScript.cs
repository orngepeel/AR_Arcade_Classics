using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public float snakeSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.forward * snakeSpeed * Time.deltaTime);

      //  float upInput = Input.GetAxis("Up");
       // float downInput = Input.GetAxis("Down");
      //  float leftInput = Input.GetAxis("Left");
       // float rightInput = Input.GetAxis("Right");

        //if key == "up":
        // y == on, positive
        // x == off
       // transform.position = transform.position + new Vector3(0, 0, verticalInput * snakeSpeed * Time.deltaTime);

        //if key == "down":
        // y == on, negative
        // x == off
       // transform.position = transform.position + new Vector3(0, 0, verticalInput * -1 * snakeSpeed * Time.deltaTime);

        //if key == "left":
        // y == off
        // x == on, negative
        //transform.position = transform.position + new Vector3(horizontalInput * -1 * snakeSpeed * Time.deltaTime, 0, 0);

        //if key == "right":
        // y == off
        // x == on, positive
        //transform.position = transform.position + new Vector3(horizontalInput * snakeSpeed * Time.deltaTime, 0, 0);

        //update the position
        //transform.position = transform.position + new Vector3(horizontalInput * snakeSpeed * Time.deltaTime, 0, verticalInput * snakeSpeed * Time.deltaTime);

        //output to log the position change
     //   Debug.Log(transform.position);
    }
}
