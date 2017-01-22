using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private Text scoreText;
    private int currentScore = 0;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	public void SetScore( int score )
    {
        scoreText.text = "" + score;
        currentScore = score;
    }

    public void AddWin()
    {
        SetScore( currentScore + 1 );
    }
}
