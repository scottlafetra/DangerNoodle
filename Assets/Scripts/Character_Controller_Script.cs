using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_Script : MonoBehaviour {
    public Rigidbody2D CharacterRigid;
    public float maxSpeed;              // Max speed for character
    public bool facingRight = true;     // Used to flip animations
    public Interpreting_Input_Script Interpret_Input_Script;

	// Use this for initialization
	void Start () {
        Interpret_Input_Script = GetComponent<Interpreting_Input_Script>();
        CharacterRigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("move_X") * maxSpeed;
        float moveVertical = Input.GetAxis("move_Y") * maxSpeed;
        //print(moveHorizontal);
        CharacterRigid.velocity = Interpret_Input_Script.ApplyRadialDeadZone(new Vector2(moveHorizontal, moveVertical));

        print(Interpret_Input_Script.ApplyRadialDeadZone(new Vector2(moveHorizontal, moveVertical)));

        /*
        CharacterRigid.velocity = new Vector2(moveHorizontal * maxSpeed, moveVertical * maxSpeed);
        if (moveHorizontal > 0 && !facingRight)     // If moving left and not facing left flip it.
            Flip();
        else if (moveHorizontal < 0 && facingRight) // If moving to the right and not facing right flip it.
            Flip();	
            */
    }

    /* Flip animation
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    */
}
