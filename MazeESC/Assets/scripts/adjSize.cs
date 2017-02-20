using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjSize : MonoBehaviour {
    int N = 0;
    Vector3 sizeOfGrid; // this is affecting the scale of the object "plane" in which it is  assing to. adding 0.2 to the scale is needed to populate one extra square.
	//N must be read from file
	
	void Update () {
        sizeOfGrid = transform.localScale;
        sizeOfGrid.x = ((N - 10F) * 0.1F)+1F;
        sizeOfGrid.y = 1.0F;
        sizeOfGrid.z = ((N - 10F) * 0.1F) + 1F;
        transform.localScale = sizeOfGrid;
    }
}
