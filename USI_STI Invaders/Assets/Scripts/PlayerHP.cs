using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour 
{
	public float playerHP;
	public Text healthText;

	public int basicDamage = 10;
	// Use this for initialization
	void Start () 
	{
		playerHP = 100;
		SetHealthText();
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag == "Respawn")
		{
			// use this for pooling when ready
			//other.gameObject.SetActive(false);
			playerHP -= basicDamage;
			SetHealthText();
		}
	}
	void SetHealthText()
	{
		healthText.text = "Health: " + playerHP.ToString ();
	
	}
}
