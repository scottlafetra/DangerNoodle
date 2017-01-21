using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsOnClick : MonoBehaviour {

    public GameObject toSpawn;
	
	void Update () {
		if ( Input.GetMouseButtonDown(0) )
        {
            Instantiate( toSpawn, transform.position, transform.rotation );
        }
	}
}
