using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracksPlayerCharge : MonoBehaviour {

    public MouseFollower player;

    private Image chargeBar;
	
	void Start()
    {
        chargeBar = GetComponent<Image>();
    }

	void Update ()
    {
        if( player.fired )
        {
            chargeBar.fillAmount = Mathf.Min( ( Time.time - player.timerStart ) / player.limit, 1 );
        }
        else
        {
            chargeBar.fillAmount = 0;
        }
        	
	}
}
