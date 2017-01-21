using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampedToRect : MonoBehaviour {

    public float maxX, minX, maxY, minY;

	void LateUpdate () {
        transform.position = new Vector3( Mathf.Clamp( transform.position.x, minX, maxX ),
                                          Mathf.Clamp( transform.position.y, minY, maxY ) );
	}
}
