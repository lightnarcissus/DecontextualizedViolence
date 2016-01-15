using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnCubes : MonoBehaviour {

	public int cubeLimit=10;
	public static int currentCubes=0;
	public GameObject cube;
	public List<GameObject> cubeList; 
	private GameObject tempCube;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("CubeSpawn", 1f, 0.3f);
		InvokeRepeating ("UpdateCubeLimit", 10f, 10f);
		for (int i=0; i<cubeLimit; i++) {

			tempCube=Instantiate (cube,new Vector3(Random.Range (-2.3f,2.3f),Random.Range (-3.5f,5.52f),0f),Quaternion.identity) as GameObject;
			cubeList.Add (tempCube);
			currentCubes++;
		}
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


	
	}

	public void UpdateCubeLimit()
	{
		cubeLimit += 10;
	}


	public void CubeSpawn()
	{
		if(!StateManager.gameOver)
		if (currentCubes < cubeLimit) {
			tempCube=Instantiate (cube,new Vector3(Random.Range (-2.3f,2.3f),Random.Range (-3.5f,5.52f),0f),Quaternion.identity) as GameObject;
			cubeList.Add (tempCube);
			currentCubes++;
		}
	}
}
