using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        transform.Translate( Input.GetAxis("Horizontal") * Time.deltaTime * speed, 
            Input.GetAxis( "Vertical" ) * Time.deltaTime * speed, 
            0, 
            Space.World );
	}
}
