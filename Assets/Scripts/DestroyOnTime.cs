using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    public float lifetime;
    private float timeOfDeath;

    void Start()
    {
        timeOfDeath = Time.time + lifetime;
    }

	void Update ()
    {
        if( Time.time > timeOfDeath )
        {
            Destroy( gameObject );
        }
    }
}
