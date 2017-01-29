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

    //EnemyAI[] enemies;
    List<EnemyAI> enemies;
    List<GameObject> bullets;
    public int pooledAmount;
    public GameObject bullet;

    void Start()
    {
        // this creates a list of bullets at start
        bullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        enemies = new List<EnemyAI>();
        EnemyAI[] enemiesComp = this.GetComponentsInChildren<EnemyAI>();
        foreach(EnemyAI ec in enemiesComp)
        {
            enemies.Add(ec);
        }
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

        if (enemies.Count > 0)
        {
            foreach (EnemyAI e in enemies)
            {
                //float posX = e.transform.position.x + e.transform.parent.position.x;
                float posX = e.transform.position.x;


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
        return false;
    }

    void PickShooter()
    {
        if (enemies.Count > 0)
        {
            int rnd = Random.Range(0, enemies.Count);
            for (int i = 0; i < bullets.Count; i++)
            {
                // if the bullets are not active in hierarchy, use it
                if (!bullets[i].activeInHierarchy)
                {
                    // this uses bullet from list and sets it to active
                    enemies[rnd].Shoot(bullets[i]);
                    break;
                }
            }
        }
    }

    IEnumerator MoveDown()
    {
        CancelInvoke("MoveTick");
        yield return new WaitForSeconds(pauseTime);
        transform.position += new Vector3(0, -1, 0);
        InvokeRepeating("MoveTick", initialDelay, delay);
    }

    public void RemoveEnemy(EnemyAI e)
    {
        /*EnemyAI[] enemies2 = enemies;
        int newCount = enemies.Length;
        enemies = new EnemyAI[newCount - 1];
        foreach (EnemyAI enemy in enemies2)
        {
            if(enemy != e)
            {
                
            }
        }*/
        enemies.Remove(e);

    }
}
