using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodManager : MonoBehaviour {

	public GameObject scoreKeeper;
	private int level=0;
	public GameObject cubeManager;
	public List<GameObject> bloodList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//add blood obj to list
	public void AddBlood(GameObject bloodObj)
	{
		bloodList.Add (bloodObj);
	}

	public void UpdateBlood(int level)
	{
		//Debug.Log ("ji");
		cubeManager.GetComponent<SpawnCubes> ().UpdateCubeLimit ();
		for(int i=0;i<bloodList.Count;i++)
		{
			//Debug.Log ("ji");
			bloodList[i].transform.localScale/=level;
		}
		if (level >= 2) {
			cubeManager.GetComponent<CubeManager>().SpawnSpheres();
		}
	}
}
