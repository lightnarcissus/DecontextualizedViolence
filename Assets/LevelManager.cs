using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Application.targetFrameRate = 30;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			Application.LoadLevel("Main");
		}
	
	}



}
