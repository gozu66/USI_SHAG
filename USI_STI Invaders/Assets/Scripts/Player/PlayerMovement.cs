using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public static bool canMove = false;

	public float playerSpeed;
	//public float smoothTime = 0.4f;
	public float minX = -5.0f;
	public float maxX = 5.0f;

	// Update is called once per frame
	void Update () 
	{
		float myDir = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

		transform.position += new Vector3(myDir, 0,0f);
		CheckBounds();
	}
	void CheckBounds()
	{
		if(this.transform.position.x < minX)
		{
			this.transform.position = new Vector3(maxX, this.transform.position.y, this.transform.position.z);
		}
		if(this.transform.position.x > maxX)
		{
			this.transform.position = new Vector3(minX, this.transform.position.y, this.transform.position.z);
		}
	}
}

