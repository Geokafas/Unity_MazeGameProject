using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour {

    public GameObject Target;
    private Vector3 point;

    private void Start()
    {
        point = Target.transform.position;
        transform.LookAt(point);
        GameControl.control.rotateCam();
    }
    void Update ()
    {
        transform.RotateAround(point, Vector3.up, 20*Time.deltaTime);
    }
}
