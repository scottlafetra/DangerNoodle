using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreting_Input_Script : MonoBehaviour {
    float deadZoneHigh = 0.9f;
    float deadZoneLow = 0.25f;
    // Remove input inconsistencies
    public Vector2 ApplyRadialDeadZone(Vector2 V2_Input) {

        if (V2_Input.magnitude < deadZoneLow) {
            V2_Input = Vector2.zero;
        }
        else if (V2_Input.magnitude > deadZoneHigh){
            V2_Input = V2_Input.normalized;
        }
        else {
            V2_Input = V2_Input.normalized * ((V2_Input.magnitude - deadZoneLow) / (1 - deadZoneLow));
        }

        return V2_Input;
    }

    // Quadratic sensitivity curve
    public Vector2 applySensitivity_1to4(Vector2 V2_Input, float sensitivity) {
        Vector2 V2_adjusted = new Vector2(0,0);
        if (sensitivity < 1){
            sensitivity = 1;
        }

        if (sensitivity > 4){
            sensitivity = 4;
        }

        sensitivity += 1;
        // Exponential sensitivity curve
        // 1st Quadrant
        if (V2_Input.x > 0 && V2_Input.y > 0) {
            // y = sensitivity^x - 1
            V2_adjusted.x = Mathf.Pow(sensitivity, V2_Input.x) - 1;
            // x = sensitivity^y - 1
            V2_adjusted.y = Mathf.Pow(sensitivity, V2_Input.y) - 1;
        }
        // 2nd Quandrant
        else if (V2_Input.x < 0 && V2_Input.y > 0) {
            // y = sensitivity^-x - 1
            V2_adjusted.x = -Mathf.Pow(sensitivity, -V2_Input.x) + 1;
            // x = sensitivity^y - 1
            V2_adjusted.y = Mathf.Pow(sensitivity, V2_Input.y) - 1;
        }
        // 3rd Quadrant
        else if (V2_Input.x < 0 && V2_Input.y < 0) {
            // y = 1- sensitivity^-x
            V2_adjusted.x = 1 - Mathf.Pow(sensitivity, -V2_Input.x);
            // x = 1 - sensitivity^-y
            V2_adjusted.y = 1 - Mathf.Pow(sensitivity, -V2_Input.y);
        }
        // 4th Quadrant
        else if(V2_Input.x > 0 && V2_Input.y < 0) {
            // y = sensitivity^x - 1
            V2_adjusted.x = Mathf.Pow(sensitivity, V2_Input.x) - 1;
            // x = 1 - sensitivity^-y
            V2_adjusted.y = 1 -Mathf.Pow(sensitivity, -V2_Input.y);
        }
        return V2_adjusted;
    }
}