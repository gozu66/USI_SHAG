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


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            Destroy(other.gameObject);  //RE-Pool bullet object
            Destroy(gameObject);        //Destroy enemy instance
        }
    }


    public GameObject bullet;
    public void Shoot()
    {
        GameObject aBullet;
        aBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;

        switch (enemyType)
        {
            case EnemyType.Chlamydia:
                aBullet.GetComponent<EnemyBullet>().speed = 1;
                break;

            case EnemyType.Gonorrhoea:
                aBullet.GetComponent<EnemyBullet>().speed = 5;
                break;

            case EnemyType.Herpes:
                break;

            case EnemyType.GenitalWarts:
                break;

            case EnemyType.HIV:
                break;
        }
        
    }
}