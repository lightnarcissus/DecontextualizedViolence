﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {

	public Text debugText;
	private Vector3 accVec;
	public static string ok;
	// Use this for initialization
	void Start () {

		debugText.gameObject.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {

		accVec = Input.acceleration;
		debugText.text = ok;
	
	}
}
