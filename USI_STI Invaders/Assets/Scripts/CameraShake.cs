using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake _camS;
    GameObject cam;

    void Start()
    {
        if(_camS == null)
        {
            _camS = this;
        }
        else
        {
            //Destr
        }

        cam = this.gameObject;
    }

    public void StartShake(float sAmt)
    {
        t = 0.5f;
        StopAllCoroutines();
        StartCoroutine(Shake(sAmt));
    }

    float t = 0.5f;
    public float shakeAmount;
    IEnumerator Shake(float sAmt)
    {
        shakeAmount = sAmt;
        //Debug.Log(shakeAmount);
        //Debug.Log(t);

        while (t > 0)
        {
            cam.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
            t -= Time.deltaTime;
            yield return null;
        }        
    }
}
