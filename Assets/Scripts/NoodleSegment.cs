using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleSegment : MonoBehaviour {

    public float forwardSpeed;
    public float amplitude;
    public float period;

    public float lifetime;

    public GameObject visuals;

    public LineHandler lineHandler;

    private float endTime;
    private float startTime;

    //Calculus stuff
    private float innerConstant;
    /*
    //TODO: Remove
    private float maxX = 0;
    private float minX = 0;*/

    void Start()
    {
        startTime = Time.time;
        endTime = startTime + lifetime;

        innerConstant = ( 2 * Mathf.PI ) / period;

        lineHandler.AddSegment( gameObject );
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > endTime )
        {
            GetComponent<EventOnTriggerEnter>().OnTriggerEnter2D( null );
        }

        // Move the wiggle
        transform.Translate( Vector3.right * Time.deltaTime * amplitude * innerConstant * Mathf.Cos( innerConstant * ( Time.time - startTime ) ));

        // Move forward
        transform.Translate( Vector3.up * forwardSpeed * Time.deltaTime );

        /*
        maxX = Mathf.Max( maxX, transform.position.x );
        minX = Mathf.Min( minX, transform.position.x );
        Debug.Log( "Max: " + maxX + " Min: " + minX);*/

        
    }
}
