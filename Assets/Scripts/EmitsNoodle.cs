using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitsNoodle : MonoBehaviour {

    public float noodleTimeSpacing;
    public int noodleLength;

    public float noodlePeriod; // 0 to 1 values
    public float lifetimeRange; // 0 to 1 values

    public GameObject noodleSegment;

    private int noodlesEmitted = 0;
    private float nextNoodleTime;

    public GameObject lineRenderer;
    private LineHandler lineHandler;

    private bool emitting = true;

	// Use this for initialization
	void Start () {

        lineHandler = Instantiate( lineRenderer ).GetComponent<LineHandler>();
        lineHandler.gameObject.SetActive( true );

        StartCoroutine( EmitNoodles() );
	}

    void UpdateNoodleTime()
    {
        nextNoodleTime = Time.time + noodleTimeSpacing;
    }

    public void StopEmitting()
    {
        emitting = false;
    }
	
	IEnumerator EmitNoodles()
    {
        UpdateNoodleTime();
        noodlesEmitted = 0;
        float endTime = noodleTimeSpacing * noodleLength;
        while( Time.time < noodleLength )
        {
            // Wait until next time to emit
            while( Time.time < nextNoodleTime )
            {
                yield return null;
            }
            UpdateNoodleTime();

            if( !emitting )
            {// stop emitting
                break;
            }

            // Emit a noodle Segment
            NoodleSegment newSegment = Instantiate( noodleSegment, transform.position, transform.rotation ).GetComponent<NoodleSegment>();
            newSegment.period *= noodlePeriod;
            newSegment.lifetime *= lifetimeRange;
            newSegment.lineHandler = lineHandler;
            newSegment.gameObject.GetComponent<EventOnTriggerEnter>().triggered += new EventOnTriggerEnter.NoodleTriggeredHandler( StopEmitting );
            newSegment.gameObject.SetActive( true );
            noodlesEmitted += 1;
        }
    }
}
