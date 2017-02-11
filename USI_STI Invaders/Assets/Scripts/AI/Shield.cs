using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //public static Shield _instance;
    Animator anim;

    public AudioClip shieldUp, shieldDown;

    void OnEnable()
    {
        AudioSource.PlayClipAtPoint(shieldUp, new Vector3(0, 0, -10), 0.7f);
    }

    void Start()
    {
        /*if(_instance != null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        anim = GetComponent<Animator>();
    }
    public void hit()
    {
        anim.SetTrigger("hit");
        AudioSource.PlayClipAtPoint(shieldDown, new Vector3(0, 0, -10), 0.5f);
    }
    public void OnAnimEnd()
    {
        anim.ResetTrigger("hit");
        gameObject.SetActive(false);
    }
}