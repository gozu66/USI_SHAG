using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour 
{
	public Text scoreText;
	public int score;

	void Start () 
	{
		score = 0;
		updateScore();
	}
	    void updateScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}

    public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		updateScore();
	}
}
