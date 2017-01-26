using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float playerSpeed;
	//public float smoothTime = 0.4f;
	public float minX = -5.0f;
	public float maxX = 5.0f;

	// Update is called once per frame
	void Update () 
	{
		float myDir = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

		transform.position += new Vector3(myDir, 0,0f);

		if(transform.position.x < minX)
		{
			transform.position = new Vector3(minX, transform.position.y, transform.position.z);

		}
		else if(transform.position.x > maxX)
		{
			transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

		}
	}
}
