using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
	public GameObject bullet;
	public float firstBullet = 0.01f;
	public float fireTime = 0.0f; 
	public int pooledAmount = 15;

	List<GameObject> bullets;

	void Start () 
	{
		// this creates a list of bullets at start
		bullets = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject) Instantiate(bullet);
			obj.SetActive(false);
			bullets.Add(obj);
		}
	}
	
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			InvokeRepeating( "Fire", firstBullet , fireTime); 
		}
		else if(Input.GetKeyUp("space"))
		{
			CancelInvoke();
		}
	}

	void Fire()
	{
		for(int i = 0; i < bullets.Count; i++)
		{
			// if the bullets are not active in hierarchy, use it
			if(!bullets[i].activeInHierarchy)
			{
				// this uses bullet from list and sets it to active
				bullets[i].transform.position = transform.position;
				bullets[i].transform.rotation = transform.rotation;
				bullets[i].SetActive(true);
				break;
			}
		}
	}

    public void CancelFireOnDeath()
    {
        /*
         * Called on player death to counteract bug where 
         * player dies before invoke can be cancelled and 
         * the player keeps shooting rockets post-mortem.
         */

        CancelInvoke();
    }
}
