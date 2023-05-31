using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public Vector3 startPosition;
    public BoxCollider GridArea;

    private void RandomizePosition() {
        Bounds bounds = GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        transform.position = new Vector3(x, y, z);
                //Output to the console the center and size of the Collider volume

        Debug.Log("Collider bound Minimum : " + bounds.min);
        Debug.Log("Collider bound Maximum : " + bounds.max);
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
