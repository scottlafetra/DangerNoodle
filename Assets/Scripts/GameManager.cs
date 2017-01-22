using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> players;
    public List<Transform> spawnPoints;

    public GameObject menu;
    public GameObject creditStuff;

    public static GameManager instance;

	// Use this for initialization
	void Start () {
        instance = this;

        EnterMenu();
	}

    public void StartGame()
    {
        creditStuff.SetActive( false );
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

        creditStuff.SetActive( false );
        foreach( GameObject player in players )
        {
            player.SetActive( false );
        }
    }

    public void EnterCredits()
    {
        creditStuff.SetActive( true );

        menu.SetActive( false );
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
