using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyType
    {
        Chlamydia,
        Gonorrhoea,
        Herpes,
        GenitalWarts,
        HIV
    };
    public EnemyType enemyType;

    public ScoreManager sm;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            StartCoroutine(Die());                              //Destroy enemy instance
            other.gameObject.SetActive(false);
        }
    }

    public GameObject bullet;
    public void Shoot(GameObject aBullet)
    {
        //GameObject aBullet;
        //aBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject

        switch (enemyType)
        {
            case EnemyType.Chlamydia:
                aBullet.GetComponent<EnemyBullet>().speed = 4;
                break;

            case EnemyType.Gonorrhoea:
                aBullet.GetComponent<EnemyBullet>().speed = 6;
                break;

            case EnemyType.Herpes:
                aBullet.GetComponent<EnemyBullet>().speed = 7;
                break;

            case EnemyType.GenitalWarts:
                aBullet.GetComponent<EnemyBullet>().speed = 8;
                break;

            case EnemyType.HIV:
                aBullet.GetComponent<EnemyBullet>().speed = 10;
                break;
        }

        aBullet.transform.position = transform.position;
        aBullet.SetActive(true);

    }

    
    IEnumerator Die()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(2);
        sm.AddScore(10);        
        transform.parent.GetComponent<EnemyGroup>().RemoveEnemy(this);
        Destroy(gameObject);
    }
}