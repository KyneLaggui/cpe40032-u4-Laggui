using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;//Rotation speed of the camera
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");//To get the horizontal input from the player
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);//To rotate the camera depending on the horizontal input
    }
}
