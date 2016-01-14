using UnityEngine;
using System.Collections;

public class MoveRandomly : MonoBehaviour {

	private Vector3 targetVec;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("SetNewTarget", 1f, 1f);
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, targetVec, Time.deltaTime * 0.1f);
	
	}

	public void SetNewTarget()
	{
		targetVec = new Vector3 (Random.Range (-4.3f, 4.3f)+1f, Random.Range (-7.5f, 7.52f)+1f, 0f);
	}
}
