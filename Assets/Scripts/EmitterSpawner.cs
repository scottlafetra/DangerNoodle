using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpawner : MonoBehaviour {

    public GameObject emitter; 
	
	public void Spawn(float range, float period)
    {
        EmitsNoodle newEmitter = Instantiate( emitter, transform.position, transform.rotation ).GetComponent<EmitsNoodle>();
        newEmitter.noodlePeriod = period;
        newEmitter.lifetimeRange = range;
    }
}
