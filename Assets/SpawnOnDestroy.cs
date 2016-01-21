using UnityEngine;
using System.Collections;

public class SpawnOnDestroy : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		transform.parent.GetComponent<SpawnCubes> ().SpawnMore (5,transform.position);
	}
}
