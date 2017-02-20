using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smashAnimation : MonoBehaviour {

	public void attack()
    {
        GetComponent<Animation>().Play();
        print("Attack!");
    }
}
