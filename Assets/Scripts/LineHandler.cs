using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour {

    private List<Transform> positions = new List<Transform>();
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
        lineRenderer.numPositions = positions.Count;

        List<Vector3> actualPositions = new List<Vector3>();
        foreach( Transform segTransform in positions )
        {
            if( segTransform != null )
            {
                actualPositions.Add( segTransform.position );
            }
            
        }

        lineRenderer.SetPositions( actualPositions.ToArray() );
    }
	
    public void AddSegment( Transform segment)
    {
        positions.Add( segment );
    }
    /*
    public void RemoveSegment(Vector3 segment)
    {
        
        RemoveSegment( positions.IndexOf( segment ) );
    }*/

    public void RemoveSegment(int index)
    {
        positions.RemoveAt( index );

        if( positions.Count == 0 )
        {
            Destroy( gameObject );
        }
    }
}
