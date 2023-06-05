using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public Vector3 startPosition;
    public BoxCollider GridArea;

    private void RandomizePosition() {
        Bounds bounds = GridArea.bounds;


        // GridArea.bounds are showing (0, 0, -0.2) for both min and max -- need to get an actual boundary working
        float x = Random.Range(-0.65f, 0.65f);
        float y = -0.2f;
        float z = Random.Range(-0.65f, 0.65f);

        // the y value also appears to be floating off outside of the actual bounds
        transform.position = new Vector3(x, y, z);
        
        //Output to the console the center and size of the Collider volume

    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //RandomizePosition();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snake")) {
            RandomizePosition();
        }
    }


}
