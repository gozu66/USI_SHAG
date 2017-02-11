using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {

    public GameObject hitPtl;
    public AudioClip hitAudio;
    void OnTriggerEnter2D(Collider2D other)
    {
        //SPawn Particles
        if (other.tag == "EnemyBullet" || other.tag == "PlayerBullet" || other.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, -10), 0.3f);
            Instantiate(hitPtl, transform.position, Quaternion.identity);
            CameraShake._camS.StartShake(0.25f);
            if (other.tag != "Enemy")
            {
                other.gameObject.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
