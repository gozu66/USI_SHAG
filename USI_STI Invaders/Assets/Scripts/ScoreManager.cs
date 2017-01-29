using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour 
{
	public Text scoreText;
	public int score;
	// Use this for initialization
	void Start () 
	{
		score = 0;
		updateScore();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
