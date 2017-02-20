using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.control.exitMode)
        {
            
            GetComponent<Renderer>().sharedMaterial = GameControl.control.redTrans;
        }
    }
}
