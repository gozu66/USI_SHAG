using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {

    public float moveAmount;
    public float pauseTime;
    public float initialDelay, delay;

    public float moveDownAmount;

    public float shootIntervile;

    //EnemyAI[] enemies;
    List<EnemyAI> enemies;
    List<GameObject> bullets;
    public int pooledAmount;
    public GameObject bullet;

    public GameObject[] pickUps;
    GameObject[] _pickUps;

    bool dead;

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

        _pickUps = new GameObject[3];
        for(int index = 0; index < 3; index++)
        {
            _pickUps[index] = Instantiate(pickUps[index]);
            _pickUps[index].SetActive(false);
        }

        InvokeRepeating("SpawnPickup",3,3);
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
                    //Debug.Log(screenEdge - Mathf.Abs(posX));

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
        yield return new WaitForSeconds(delay);
        if (transform.position.y > -3.5f)
        {
            transform.position += new Vector3(0, -1, 0);
        }
        InvokeRepeating("MoveTick", initialDelay, delay);
    }

    public void RemoveEnemy(EnemyAI e)
    {
        enemies.Remove(e);
        if(enemies.Count <= 0)
        {
            GameManager._instance.EndWave(gameObject);
            dead = true;
            this.gameObject.SetActive(false);
        }
    }

    int i = 0;
    void SpawnPickup()
    {
        if (!dead)
        {
            _pickUps[i].SetActive(true);
            _pickUps[i].transform.position = new Vector2(Random.Range(-8.2f, 8.2f), 11.0f);
            i = (i < 2) ? i += 1 : 0;
        }
    }

    void OnDisable()
    {
        CancelInvoke("MoveTick");
        CancelInvoke("PickShooter");
        CancelInvoke("SpawnPickup");
    }
}
