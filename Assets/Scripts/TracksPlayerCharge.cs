using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracksPlayerCharge : MonoBehaviour {

    public PlayerController player;

    public float intensity = 6;
    public float idle = 0.5f;

    private Light chargeLight;
	
	void Start()
    {
        chargeLight = GetComponent<Light>();
    }

	void Update ()
    {
        if( player.fired )
        {
            chargeLight.intensity = Mathf.Max( Mathf.Min( ( Time.time - player.timerStart ) / player.limit, 1 ) * intensity, idle) ;
        }
        else
        {
            chargeLight.intensity = idle;
        }
        	
	}
}
