using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyDisplay : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Input.GetAxis("move_X"), Input.GetAxis("move_Y"));
	}
}
