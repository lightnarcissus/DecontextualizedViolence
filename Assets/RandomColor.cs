using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	public Color[] randColors;

	// Use this for initialization
	void Start () {

		GetComponent<Renderer>().material.color=randColors[Random.Range(0,7)];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
