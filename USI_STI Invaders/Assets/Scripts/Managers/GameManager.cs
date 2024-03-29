﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public GameObject player;

    public GameObject chlamydia, gonorrhea, herpes, gWarts, hiv;
    public GameObject chlamydiaUI, gonorrheaUI, herpesUI, gWartsUI, hivUI, menu, win, lose;
    //int[] states = {0, 1, 2, 3, 4, 5, 6, 7};
    //int currState;

    AudioSource[] myASs;

    Animator MenuAnim;

    bool isPaused;

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

        MenuAnim = menu.GetComponent<Animator>();
        myASs = GetComponents<AudioSource>();
	}
	
	void Update ()
    {
       /* if(Input.GetKeyDown(KeyCode.H))
        {
            state = gameState.Winner;
            Winner();
        }*/

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
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);
                }
                break;
            case gameState.Dead:
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }

    void MainMenu()
    {
        //Play menu animation
        //Wait for input
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(BeginWave(chlamydia, 2.5f));
            MenuAnim.SetTrigger("Out");
        }
    }
    
    public AudioClip winSound, winMusic;
    void Winner()
    {
        win.SetActive(true);
        StartCoroutine(WinAudio());
    }

    IEnumerator WinAudio()
    {
        AudioSource aSrc = aSrc = GetComponent<AudioSource>();
        aSrc.loop = false;
        aSrc.clip = winSound;
        aSrc.Play();
        while(aSrc.isPlaying)
        {
            yield return null;
        }
        aSrc.clip = winMusic;
        aSrc.loop = true;
        aSrc.Play();
    }

    public void Dead()
    {
        lose.SetActive(true);
        chlamydia.SetActive(false);
        gonorrhea.SetActive(false);
        herpes.SetActive(false);
        gWarts.SetActive(false);
        hiv.SetActive(false);
        player.GetComponent<PlayerShoot>().CancelFireOnDeath();
        player.SetActive(false);
        state = gameState.Dead;
    }

    IEnumerator BeginWave(GameObject waveToSpawn, float wait)
    {
        switch (state)
        {
            case gameState.MainMenu:
                chlamydiaUI.SetActive(true);
                myASs[1].PlayDelayed(0.5f);
                state = gameState.Wave1;

                break;
            case gameState.Wave1:
                break;
            case gameState.Wave2:
                gonorrheaUI.SetActive(true);
                myASs[1].PlayDelayed(0.5f);

                break;
            case gameState.Wave3:
                herpesUI.SetActive(true);
                myASs[1].PlayDelayed(0.5f);

                break;
            case gameState.Wave4:
                gWartsUI.SetActive(true);
                myASs[1].PlayDelayed(0.5f);

                break;
            case gameState.Wave5:
                hivUI.SetActive(true);
                myASs[1].PlayDelayed(0.5f);

                break;
            case gameState.Winner:
                //
                break;
            case gameState.Dead:
                //
                break;
        }

        yield return new WaitForSeconds(wait);          //wait for menu exit anim and/or Wave intro anim
        waveToSpawn.SetActive(true);                    
    }

    public void EndWave(GameObject waveToEnd)
    {
        waveToEnd.SetActive(false);

        switch (state)
        {
            case gameState.MainMenu:
                state = gameState.Wave1;
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
                Winner();
                break;
            case gameState.Winner:
                
                break;
            case gameState.Dead:
                //
                break;
        }

    }

    public void Pause()
    {
        isPaused = !isPaused;
    }
}
