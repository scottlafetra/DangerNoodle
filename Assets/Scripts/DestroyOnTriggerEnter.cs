using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour {
    public string exceptionTag = "";

    public delegate void NoodleTriggeredHandler();
    public event NoodleTriggeredHandler triggered;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if( other == null || other.tag != exceptionTag ) // if manually triggered or not an exception
        {
            triggered();
            Destroy( gameObject );
        }
    }
}
