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

	// Use this for initialization
	void Start () {

        lineHandler = Instantiate( lineRenderer ).GetComponent<LineHandler>();

        StartCoroutine( EmitNoodles() );
	}

    void UpdateNoodleTime()
    {
        nextNoodleTime = Time.time + noodleTimeSpacing;
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

            // Emit a noodle Segment
            NoodleSegment newSegment = Instantiate( noodleSegment, transform.position, transform.rotation ).GetComponent<NoodleSegment>();
            newSegment.period *= noodlePeriod;
            newSegment.lifetime *= lifetimeRange;
            newSegment.lineHandler = lineHandler;
            noodlesEmitted += 1;
        }
    }
}
