using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> players;
    public List<Transform> spawnPoints;

    public GameObject menu;

	// Use this for initialization
	void Start () {
		
	}

    public void StartGame()
    {
        menu.SetActive( false );

        for( int i = 0; i < players.Count; ++i )
        {
            players[i].SetActive( true );
            players[ i ].transform.position = spawnPoints[ i ].position;
            players[ i ].transform.rotation = spawnPoints[ i ].rotation;
            players[ i ].GetComponent<Rigidbody2D>().velocity = new Vector2();
        }
    }

    public void EnterMenu()
    {
        menu.SetActive( true );

        foreach( GameObject player in players )
        {
            player.SetActive( false );
        }
    }
	
	public void CheckForWin()
    {
        bool oneStanding = false;

        foreach( GameObject player in players )
        {
            if( player.activeSelf )
            {
                if( oneStanding )
                {
                    //no win
                    return; 
                }

                oneStanding = true;
            }
        }

        if( oneStanding )
        {
            //win
        }
        else
        {
            // all lose
        }
    }
}
