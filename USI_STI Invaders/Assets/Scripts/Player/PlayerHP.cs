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

    public AudioClip hit;
    public GameObject hitPtl, hitPtl2;

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
                AudioSource.PlayClipAtPoint(hit, new Vector3(0, 0, -10), 0.4f);
                Instantiate(hitPtl, transform.position, Quaternion.identity);
                Instantiate(hitPtl2, transform.position, Quaternion.identity);
                CameraShake._camS.StartShake(0.5f);
                playerHP -= basicDamage;
                other.gameObject.SetActive(false);

                SetHealthText();

                if(playerHP <= 0)
                {
                    Instantiate(hitPtl, transform.position, Quaternion.identity);
                    Instantiate(hitPtl, transform.position, Quaternion.identity);
                    Instantiate(hitPtl, transform.position, Quaternion.identity);

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
            ScoreManager._instance.AddScore(50);
            other.gameObject.SetActive(false);
            theShield.SetActive(true);
        }
        if (other.tag == "Enemy")
        {
            playerHP = 0;
            //CancelInvoke
            GameManager._instance.Dead();           
        }
    }
	void SetHealthText()
	{
		healthText.text = "Health: " + playerHP.ToString ();
    }
}
