using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {

    public float returnPoint;
    public float moveAmount;
    public float pauseTime;
    public float initialDelay, delay;

    public float moveDownAmount = 0.5f;

    public float shootIntervile;

    EnemyAI[] enemies;

    void Start ()
    {       
        enemies = this.GetComponentsInChildren<EnemyAI>();
        InvokeRepeating("MoveTick", initialDelay, delay);
        InvokeRepeating("PickShooter", shootIntervile, shootIntervile);
    }
	
    void MoveTick()
    {
        //Enemy moves left or right
        //Sound is played
        //If enemy block has reached screen edge, mocve down, revese direction
        transform.position += new Vector3(moveAmount, 0, 0);

        //if(transform.position.x > returnPoint || transform.position.x < -returnPoint)
        if(CheckEdges())
        {
            moveAmount = -moveAmount;
            StartCoroutine(MoveDown());
        }
    }    

    bool CheckEdges()
    {
        float screenEdge = 8.5f;

        foreach(EnemyAI e in enemies)
        {
            //float posX = e.transform.position.x + e.transform.parent.position.x;
            float posX = e.transform.position.x;
            Debug.Log(screenEdge - Mathf.Abs( posX));

            if (screenEdge - Mathf.Abs(posX) < moveDownAmount)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

    void PickShooter()
    {
        int rnd = Random.Range(0, enemies.Length);
        enemies[rnd].Shoot();
    }

    IEnumerator MoveDown()
    {
        CancelInvoke("MoveTick");
        yield return new WaitForSeconds(pauseTime);
        transform.position += new Vector3(0, -1, 0);
        InvokeRepeating("MoveTick", initialDelay, delay);


    }
}
