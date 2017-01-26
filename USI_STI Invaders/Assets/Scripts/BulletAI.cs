using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAI : MonoBehaviour 
{
	public float speed;
	public Text scoreText;

	private int count;
	// Use this for initialization
	void Start () 
	{
		count = 0;
		SetScoreText();
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
			count += 100;
			SetScoreText();
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + count.ToString ();

	}
}
