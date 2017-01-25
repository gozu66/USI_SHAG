using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
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
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}