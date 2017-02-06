using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public float speed;

    float timer = 0f;
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;
        transform.position = newPos;

        timer += Time.deltaTime;
        if(timer > 3f)
        {
            timer = 0f;
            this.gameObject.SetActive(false);
        }
    }
}
