﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour 
{
	void DestroyTemp()
	{
		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		Invoke("DestroyTemp", 5.0f);
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}