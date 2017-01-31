using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public GameObject chlamydia, gonorrhea, herpes, gWarts, hiv;

    int[] states = {0, 1, 2, 3, 4, 5, 6, 7};
    int currState;

 /*   public enum gameState
    {
        MainMenu, 
        Wave1,
        Wave2,
        Wave3,
        Wave4,
        Wave5,
        Dead, 
        Winner
    }
    public gameState state;
    */

	void Start ()
    {
        //Trigger main menu
        currState = states[0];
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	void Update ()
    {
	/*	switch(state)
        {
            case gameState.MainMenu:
                MainMenu();
                break;
            case gameState.Wave1:
                //
                break;
            case gameState.Wave2:
                //
                break;
            case gameState.Wave3:
                //
                break;
            case gameState.Wave4:
                //
                break;
            case gameState.Wave5:
                //
                break;
            case gameState.Winner:
                //
                break;
            case gameState.Dead:
                //
                break;
        }
        */
    }

    void MainMenu()
    {
        //Play menu animation
        //Wait for input
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(BeginWave(chlamydia, 2.5f));
            currState = states[1];
        }
    }

    IEnumerator BeginWave(GameObject waveToSpawn, float wait)
    {
        yield return new WaitForSeconds(wait);          //wait for menu exit anim and/or Wave intro anim
        //waveToSpawn.SetActive(true);                    
    }

    public void EndWave(GameObject waveToEnd)
    {
        waveToEnd.SetActive(false);
        if (currState > 7)
        {
            currState = states[currState + 1];
        }
    }
}
