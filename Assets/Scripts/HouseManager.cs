﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		string targetTag;
		targetTag = "house" + Random.Range(1,20).ToString();
	}
}
