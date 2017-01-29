using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //SPawn Particles
        if (other.tag == "EnemyBullet" || other.tag == "PlayerBullet")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
