using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpret_Joy : MonoBehaviour {
    public Interpreting_Input_Script interpret_Input_Script;
    public Vector2 V2finalOutput;

    // Use this for initialization
    void Start () {
        interpret_Input_Script = GetComponent<Interpreting_Input_Script>();
    }
	
	// Update is called once per frame
	void Update () {
        V2finalOutput = interpret_Input_Script.ApplyRadialDeadZone(new Vector2(Input.GetAxis("move_X"), Input.GetAxis("move_Y")));
        V2finalOutput = interpret_Input_Script.applySensitivity_1to4(V2finalOutput, 1);

        transform.position = V2finalOutput;


    }
}
