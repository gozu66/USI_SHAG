using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;
        transform.position = newPos;
    }
}
