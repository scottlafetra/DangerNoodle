using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class GameManager : MonoBehaviour {

    public List<GameObject> players;
    public List<Transform> spawnPoints;
    public List<ScoreKeeper> scores;

    public GameObject menu;

    public static GameManager instance;

    private bool inMenu;

	// Use this for initialization
	void Start () {
        instance = this;

        EnterMenu();
	}

    void Update()
    {
        if( !inMenu && InputManager.ActiveDevice.MenuWasPressed )
        {
            EnterMenu();
        }

        if( inMenu && InputManager.ActiveDevice.AnyButton.WasPressed )
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        inMenu = false;
        menu.SetActive( false );

        for( int i = 0; i < players.Count; ++i )
        {
            players[i].SetActive( true );
            players[ i ].transform.position = spawnPoints[ i ].position;
            players[ i ].transform.rotation = spawnPoints[ i ].rotation;
            players[ i ].GetComponent<Rigidbody2D>().velocity = new Vector2();
            players[ i ].GetComponent<PlayerController>().fired = false;
        }
        foreach( ScoreKeeper scoreKeeper in scores )
        {
            scoreKeeper.gameObject.SetActive( true );
        }
    }

    public void EnterMenu()
    {
        inMenu = true;
        menu.SetActive( true );
        
        foreach( GameObject player in players )
        {
            player.SetActive( false );
        }
        foreach( ScoreKeeper scoreKeeper in scores)
        {
            scoreKeeper.gameObject.SetActive( false );
            scoreKeeper.SetScore( 0 );
        }
        foreach( GameObject noodle in GameObject.FindGameObjectsWithTag( "Noodle" ) )
        {
            Destroy( noodle );
        }
    }
	
	public void CheckForWin()
    {
        bool oneStanding = false;
        int standingPlayer = -1;
        
        for(int i = 0; i < players.Count; ++i )
        {
            if( players[i].activeSelf )
            {
                standingPlayer = i;

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
            scores[ standingPlayer ].AddWin();
            StartCoroutine( NextRound() );
        }
        else
        {
            StartCoroutine( NextRound() );
        }
    }

    public IEnumerator NextRound()
    {
        yield return new WaitForSeconds( 1 );

        foreach( GameObject noodle in GameObject.FindGameObjectsWithTag( "Noodle" ) )
        {
            Destroy( noodle );
        }

        StartGame();
    }
}
