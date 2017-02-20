using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tcubes : MonoBehaviour {

    void Update()
    {
        if (GameControl.control.exitMode)
        {
            GetComponent<Renderer>().sharedMaterial = GameControl.control.m1Trans;
        }
    }
}
