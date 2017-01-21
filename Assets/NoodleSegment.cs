using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleSegment : MonoBehaviour {

    public float forwardSpeed;
    public float amplitude;
    public float period;

    public float lifetime;

    public GameObject visuals;

    private Vector3 forwardDirection;
    private Vector3 sideDirection;
    private Quaternion startRotation;

    private float endTime;
    private float startTime;
    /*
    //TODO: Remove
    private float maxX = 0;
    private float minX = 0;*/

    void Start()
    {
        forwardDirection = new Vector3( transform.forward.x, transform.forward.y, transform.forward.z );
        sideDirection = new Vector3( transform.right.x, transform.right.y, transform.right.z );

        startTime = Time.time;
        endTime = startTime + lifetime;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > endTime )
        {
            Destroy( gameObject );
        }

        // Move the wiggle
        transform.Translate( sideDirection * Time.deltaTime * amplitude * Mathf.Cos( ( 2 * Mathf.PI ) * ( ( Time.time - startTime ) / period ) ) , Space.World);

        // Move forward
        transform.Translate( forwardDirection * forwardSpeed * Time.deltaTime );

        // Face the right direction
        transform.rotation = startRotation * Quaternion.Euler(0, 45 * Mathf.Cos( ( 2 * Mathf.PI ) * ( ( Time.time - startTime ) / period ) ), 0);
        /*
        maxX = Mathf.Max( maxX, transform.position.x );
        minX = Mathf.Min( minX, transform.position.x );
        Debug.Log( "Max: " + maxX + " Min: " + minX);*/

        
    }
}
