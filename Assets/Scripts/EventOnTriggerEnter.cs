using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnTriggerEnter : MonoBehaviour {
    public List<string> exceptionTags = new List<string>();

    public delegate void NoodleTriggeredHandler();
    public event NoodleTriggeredHandler triggered;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if( other == null || !exceptionTags.Contains( other.tag ) ) // if manually triggered or not an exception
        {
            triggered();
        }
    }
}
