using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bcubes : MonoBehaviour {

    void Update()
    {
        if (GameControl.control.exitMode)
        {
            GetComponent<Renderer>().sharedMaterial = GameControl.control.blueTrans;
        }
    }
}
