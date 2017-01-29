using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour 
{
	// *** this is for generic pooling *** attach this to an empty game object
	// this is here so it is easier to use from other scripts
	public static ObjectPooling current;
	public GameObject pooledObject;
	public int pooledAmout;
	// leave this active if you want the list to be able to grow
	public bool canGrow = true;

	List<GameObject> pooledObjects;

	void Awake()
	{
		current = this;
	}
	void Start()
	{
        //Debug.Log(this.gameObject.name);
		pooledObjects = new List<GameObject>();
		for(int i = 0; i < pooledAmout; i++)
		{
			GameObject obj = (GameObject) Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		// if inactive return pooled object
		for(int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		if(canGrow)
		{
			// if the list can grow and needs to, it can with this
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}
		// otherwise return null as subtracting from lists are costly as you already know Rich ;) 
		return null;
	}
	
}
