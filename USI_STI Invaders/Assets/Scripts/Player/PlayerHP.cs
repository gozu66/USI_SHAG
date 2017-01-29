using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour 
{
	public float playerHP;
	public Text healthText;

	public int basicDamage = 10;

    void Start () 
	{
		playerHP = 100;
		SetHealthText();
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag == "EnemyBullet")
		{
			// use this for pooling when ready
			//other.gameObject.SetActive(false);
			playerHP -= basicDamage;
            other.gameObject.SetActive(false);
			SetHealthText();
		}
	}
	void SetHealthText()
	{
		healthText.text = "Health: " + playerHP.ToString ();
    }
}
