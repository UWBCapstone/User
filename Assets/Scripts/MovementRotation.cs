using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotation : MonoBehaviour {
    public double Scale = 10000;

    private float minX = -180.0f;
    private float maxX = 180.0f;
    private float minY = -60.0f;
    private float maxY = 60.0f;

    public float rotX = 0.0f;
    public float rotY = 0.0f;
    Quaternion origRot;
    
    // Update is called once per frame
    void Update () {
        float h = (float)Scale * -Input.GetAxis("Mouse X");
        float v = (float)Scale * -Input.GetAxis("Mouse Y");

        Vector3 temp = transform.rotation.eulerAngles + new Vector3(v, h);
        temp = clamp(temp);
        transform.Rotate(temp - transform.rotation.eulerAngles);
	}

    private Vector3 clamp(Vector3 v)
    {
        Vector3 clampedV = new Vector3(v.x, v.y, v.z);
        if(clampedV.y < minY)
        {
            clampedV.y = minY;
            Debug.Log("MinY hit");
        }
        if(clampedV.y > maxY)
        {
            clampedV.y = maxY;
            Debug.Log("MaxY hit");
        }

        return clampedV;
    }
}
