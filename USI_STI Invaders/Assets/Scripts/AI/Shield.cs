using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //public static Shield _instance;
    Animator anim;

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
    }
    public void OnAnimEnd()
    {
        anim.ResetTrigger("hit");
        gameObject.SetActive(false);
    }
}