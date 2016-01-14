using UnityEngine;
using System.Collections;

public class BackgroundChanger : MonoBehaviour {

	public AudioSource music;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		//GetComponent<Camera>().backgroundColor=new Color (Mathf.Sin (Time.time), Mathf.Cos (Time.time * 1.5f), Mathf.Sin (Time.time * 2f), 8f - (Time.time % 1f));
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//GetComponent<Camera>().backgroundColor=new Color (Mathf.Sin (Time.time), Mathf.Cos (Time.time * 1.5f), Mathf.Sin (Time.time * 2f), 8f - (Time.time % 1f));
	
	}
}
