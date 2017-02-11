using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour 
{
	public float playerHP;
	public Text healthText;

	public int basicDamage = 10;

    bool shielded;

    public GameObject theShield;

    void Start () 
	{
		playerHP = 100;
		SetHealthText();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "EnemyBullet")

        {
            // use this for pooling when ready
            //other.gameObject.SetActive(false);
            if (!shielded)
            {
                playerHP -= basicDamage;
                other.gameObject.SetActive(false);

                SetHealthText();

                if(playerHP <= 0)
                {
                    GameManager._instance.Dead();
                }
            }
            else
            {
                //flash shileds
                other.gameObject.SetActive(false);
                shielded = false;
                theShield.GetComponent<Shield>().hit();
            }
        }

        if (other.tag == "Pickup")
        {
            shielded = true;
            other.gameObject.SetActive(false);
            theShield.SetActive(true);
        }
        if (other.tag == "Enemy")
        {
            playerHP = 0;
            GameManager._instance.Dead();           
        }
    }
	void SetHealthText()
	{
		healthText.text = "Health: " + playerHP.ToString ();
    }
}
