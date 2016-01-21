using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnCubes : MonoBehaviour {

	public int cubeLimit=10;
	public static int currentCubes=0;
	public GameObject cube;
	public GameObject sphere;
//	public List<GameObject> cubeList; 
	private GameObject tempCube;
	public bool spawnSpheres=false;
	private int level = 1;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("CubeSpawn", 1f, 0.3f);
		//InvokeRepeating ("UpdateCubeLimit", 10f, 10f);
		for (int i=0; i<cubeLimit; i++) {

			tempCube=Instantiate (cube,new Vector3(Random.Range (-2.3f,2.3f),Random.Range (-3.5f,5.52f),0f),Quaternion.identity) as GameObject;
		//	cubeList.Add (tempCube);
			tempCube.transform.parent=transform;
			currentCubes++;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {


	
	}

	public void UpdateCubeLimit()
	{
		cubeLimit += 10;
		level++;
	}

	public void SpawnMore(int number, Vector3 pos)
	{
		for (int i=0; i<number; i++) {
			tempCube=Instantiate (cube,pos,Quaternion.identity) as GameObject;
			tempCube.transform.parent=transform;
			currentCubes++;
		}
	}



	public void CubeSpawn()
	{
		if(!StateManager.gameOver)
		if (currentCubes < cubeLimit) {
			if(spawnSpheres)
			{
				if(Random.value>0.5f)
				{
					tempCube=Instantiate (sphere,new Vector3(Random.Range (-2.3f-(2.24f*(level-1)),2.3f+(2.24f*(level-1))),Random.Range (-3.5f-(2.45f*(level-1)),5.52f+(1.89f*(level-1))),0f),Quaternion.identity) as GameObject;
					tempCube.transform.parent=transform;
				}
				else
				{
					tempCube=Instantiate (cube,new Vector3(Random.Range (-2.3f-(2.24f*(level-1)),2.3f+(2.24f*(level-1))),Random.Range (-3.5f-(2.45f*(level-1)),5.52f+(1.89f*(level-1))),0f),Quaternion.identity) as GameObject;
					tempCube.transform.parent=transform;
				}
			}
			else
			{
				tempCube=Instantiate (cube,new Vector3(Random.Range (-2.3f-(2.24f*(level-1)),2.3f+(2.24f*(level-1))),Random.Range (-3.5f-(2.45f*(level-1)),5.52f+(1.89f*(level-1))),0f),Quaternion.identity) as GameObject;
				tempCube.transform.parent=transform;
			}
		//	cubeList.Add (tempCube);

			tempCube.transform.parent=transform;
			currentCubes++;
		}
	}
}
