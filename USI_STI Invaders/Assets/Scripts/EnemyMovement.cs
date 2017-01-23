using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	void Start ()
    {
        InvokeRepeating("Tick", 1f, 1f);
	}
	
	void Update ()
    {
		
	}

    void Tick()
    {
        //Enemy moves left or right
        //Sound is played
        //If enemy block has reached screen edge, mocve down, revese direction
        transform.Translate(new Vector3(1, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hghhgh");
        if (other.tag == "MainCamera")
        {
            Debug.Log("hghhgh");
        }
    }
}
