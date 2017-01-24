using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour 
{
	public float speed;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPos = transform.position;
		newPos.y += speed * Time.deltaTime;
		transform.position = newPos;
	}
}
