using UnityEngine;
using System.Collections;

public class BloodType : MonoBehaviour {

	public float bloodStickiness=0f;

	// Use this for initialization
	void Start () {
	
		bloodStickiness = Random.value;
		GetComponent<Rigidbody> ().drag = bloodStickiness * Random.Range(1f,2f);
	}
	
	// Update is called once per frame
	void Update () {
	


	
	}
}
