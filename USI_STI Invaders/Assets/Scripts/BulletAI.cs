using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAI : MonoBehaviour 
{
	public float speed;
	public int scoreValue;
	private ScoreManager scoreManager; 

	// Use this for initialization
	void Start () 
	{
		GameObject scoreManagerObject = GameObject.FindGameObjectWithTag("ScoreManager");
		if(scoreManagerObject != null)
		{
			scoreManager = scoreManagerObject.GetComponent <ScoreManager>();
		}
		if(scoreManager == null)
		{
			Debug.Log ("Can't find ScoreManager script");
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPos = transform.position;
		newPos.y += speed * Time.deltaTime;
		transform.position = newPos;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			//again use this for pooling if need be
			//other.gameObject.SetActive(false);
			scoreManager.AddScore(scoreValue);

		}
	}
		
}
