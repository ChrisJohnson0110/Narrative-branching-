/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 24/05/2023
/// Purpose : add text that will float within the scene and aim towards the camera
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        worldSpaceCanvas = GameObject.FindGameObjectWithTag("WorldSpaceCanvas").transform;
        mainCamera = Camera.main.transform;
        unit = transform.parent; 

        transform.SetParent(worldSpaceCanvas); //attach to canvas
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position); //look at camera
        transform.position = unit.position + offset; //keep text in position
    }
}
