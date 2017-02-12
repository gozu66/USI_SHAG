using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    public void Reverse()
    {
        speed -= speed * 2;
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;
        transform.position = newPos;
    }

    void OnEnable()
    {
        speed = 10;
        gameObject.tag = "EnemyBullet";
    }
}
