using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {

    public float speed;

    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2( 
            Input.GetAxis("move_X")  * speed, 
            Input.GetAxis( "move_Y" )  * speed
            );
	}
}
