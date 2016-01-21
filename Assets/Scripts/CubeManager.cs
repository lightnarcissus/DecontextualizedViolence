using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

	public GameObject bloodManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnSpheres()
	{
		GetComponent<SpawnCubes> ().spawnSpheres = true;
	}
	
}
