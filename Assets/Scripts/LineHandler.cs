using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour {

    public float timeAfterDeath;
    public float normalRadius = 0.5f;

    private List<GameObject> segments = new List<GameObject>();
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
	}

    void Update()
    {
        UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.numPositions = segments.Count;

        List<Vector3> actualPositions = new List<Vector3>();
        foreach( GameObject segment in segments )
        {
            if( segment != null )
            {
                actualPositions.Add( segment.transform.position );
            }
            
        }

        lineRenderer.SetPositions( actualPositions.ToArray() );
    }

    public void FreezeLine()
    {
        foreach( GameObject segment in segments )
        {
            // Remove destructability and movement
            Destroy( segment.GetComponent<EventOnTriggerEnter>() );
            Destroy( segment.GetComponent<NoodleSegment>() );

            // Add destroy on time
            segment.AddComponent<DestroyOnTime>().lifetime = timeAfterDeath;
        }

        // Destroy this
        gameObject.AddComponent<DestroyOnTime>().lifetime = timeAfterDeath;
    }
	
    public void AddSegment( GameObject segment)
    {
        segments.Add( segment );
        segment.GetComponent<EventOnTriggerEnter>().triggered += new EventOnTriggerEnter.NoodleTriggeredHandler( FreezeLine );
        resizeSegments();
    }

    private void resizeSegments()
    {
        for( int i = 0; i < segments.Count; ++i)
        {
            segments[i].GetComponent<CircleCollider2D>().radius = normalRadius * (i / segments.Count);
        }
    }

    public void RemoveSegment(int index)
    {
        segments.RemoveAt( index );
        
        if ( segments.Count == 0 )
        {
            Destroy( gameObject );
        }
        resizeSegments();

    }
}
