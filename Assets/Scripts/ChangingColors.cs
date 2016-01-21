using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangingColors : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Text> ().color = new Color (Mathf.Sin (Time.time), Mathf.Cos (Time.time * 1.5f), Mathf.Sin (Time.time * 2f), 8f - (Time.time % 1f));
	
	}
}
