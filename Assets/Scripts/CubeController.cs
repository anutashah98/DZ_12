using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeController : MonoBehaviour
{
    private Vector3 _pivotPoint;
    private Vector3 _axis;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
    }

    private void Move(Vector3 direction)
    {
        _pivotPoint = (direction / 2f) + (Vector3.down / 2f) + transform.position;
        _axis = Vector3.Cross(Vector3.up, direction); 
        
        var pos = transform.position;

        pos = pos + direction * Time.deltaTime;

        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_pivotPoint,0.2f);
    }
}
