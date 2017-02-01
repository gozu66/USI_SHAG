using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public GameObject chlamydia, gonorrhea, herpes, gWarts, hiv;

    //int[] states = {0, 1, 2, 3, 4, 5, 6, 7};
    //int currState;

    public enum gameState
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
    

	void Start ()
    {
        //Trigger main menu
        //currState = states[0];
        state = gameState.MainMenu;
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
		switch(state)
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
    }

    void MainMenu()
    {
        //Play menu animation
        //Wait for input
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(BeginWave(chlamydia, 2.5f));
            //currState = states[1];
            state = gameState.Wave1;
        }
    }

    void Winner()
    {

    }

    void Dead()
    {

    }

    IEnumerator BeginWave(GameObject waveToSpawn, float wait)
    {
        yield return new WaitForSeconds(wait);          //wait for menu exit anim and/or Wave intro anim
        waveToSpawn.SetActive(true);                    
    }

    public void EndWave(GameObject waveToEnd)
    {
        waveToEnd.SetActive(false);

        switch (state)
        {
            case gameState.MainMenu:
                break;
            case gameState.Wave1:
                state = gameState.Wave2;
                StartCoroutine(BeginWave(gonorrhea, 2.0f));
                break;
            case gameState.Wave2:
                state = gameState.Wave3;
                StartCoroutine(BeginWave(herpes, 2.0f));
                break;
            case gameState.Wave3:
                state = gameState.Wave4;
                StartCoroutine(BeginWave(gWarts, 2.0f));
                break;
            case gameState.Wave4:
                state = gameState.Wave5;
                StartCoroutine(BeginWave(hiv, 2.0f));
                break;
            case gameState.Wave5:
                state = gameState.Winner;
                break;
            case gameState.Winner:
                //
                break;
            case gameState.Dead:
                //
                break;
        }

    }
}
