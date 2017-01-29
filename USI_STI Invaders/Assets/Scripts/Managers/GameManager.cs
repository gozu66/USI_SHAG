using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject chlamydia, gonorrhea, herpes, gWarts, hiv;

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
	}
	
	void Update ()
    {
		
	}
}
