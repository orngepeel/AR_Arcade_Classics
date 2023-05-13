using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public GameObject objectRotate;

    public float rotatespeed = 50f;
    bool rotateStatus = false;

    public void RotateObject() {
        rotateStatus = !rotateStatus;
    }

    void Update()
    {
        if(rotateStatus) {
            objectRotate.transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
        }
    }
}
