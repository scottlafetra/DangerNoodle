using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour {
    public string exceptionTag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag != exceptionTag )
        {
            Destroy( gameObject );
        }
    }
}
