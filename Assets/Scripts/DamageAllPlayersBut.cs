using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAllPlayersBut : MonoBehaviour {

    public int exception;

	void OnTriggerEnter2D( Collider2D other )
    {
        if( other.tag == "Player" )
        {
            if( exception != other.gameObject.GetComponent<PlayerController>().playerNum )
            {
                // Damage code
                other.gameObject.SetActive( false );

                // Check if someone has won
                GameManager.instance.CheckForWin();
            }
        }
    }
}
