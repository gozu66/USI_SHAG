using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float returnPoint;
    public float moveDirection;
    public float pauseTime;
    public float initialDelay, delay;

    EnemyAI[] enemies;

    void Start ()
    {
        enemies = this.GetComponentsInChildren<EnemyAI>();
        InvokeRepeating("Tick", initialDelay, delay);
        InvokeRepeating("PickShooter", 3.0f, 3.0f);
    }
	
    void Tick()
    {
        //Enemy moves left or right
        //Sound is played
        //If enemy block has reached screen edge, mocve down, revese direction
        transform.position += new Vector3(moveDirection, 0, 0);
        if(transform.position.x > returnPoint || transform.position.x < -returnPoint)
        {
            moveDirection = -moveDirection;
            StartCoroutine(MoveDown());
        }
    }    

    void PickShooter()
    {
        int rnd = Random.Range(0, enemies.Length);
        enemies[rnd].Shoot();
    }

    IEnumerator MoveDown()
    {
        CancelInvoke("Tick");
        yield return new WaitForSeconds(pauseTime);
        transform.position += new Vector3(0, -1, 0);
        InvokeRepeating("Tick", initialDelay, delay);
    }
}
