using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager _instance;
    public Text scoreText;

	public int score;

	void Start () 
	{
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
		score = 0;
		updateScore();
	}
	void updateScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}

    public void AddScore(int amountToAdd)
	{
		score += amountToAdd;
		updateScore();
	}
}
