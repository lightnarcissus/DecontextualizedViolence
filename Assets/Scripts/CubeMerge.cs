using UnityEngine;
using System.Collections;

public class CubeMerge : MonoBehaviour {

	public GameObject cube;
	private GameObject tempObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log("out");
		if (gameObject.layer == 9) {
			if (col.gameObject.layer == 8) {
		
				//Destroy(this.gameObject);
				//Instantiate (cube,transform.position,Quaternion.identity);
				transform.localScale =new Vector3(transform.localScale.x+1f,transform.localScale.y+1f,transform.localScale.z+1);

				//play some effect 
				SpawnCubes.currentCubes--;
				Destroy (col.gameObject);

			}

			if(col.gameObject.layer==10)
			{
				transform.localScale=new Vector3(transform.localScale.x,transform.localScale.y+Time.deltaTime,transform.localScale.z);
			}
		}
	}

}
