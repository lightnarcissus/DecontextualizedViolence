using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustText : MonoBehaviour {

	public GameObject bloodText;
	public float movementScale=1f;
	private Rigidbody rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		InvokeRepeating ("MoveText", 0.01f, 0.1f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 pos = transform.position;
		pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * movementScale;
		rBody.AddForce(Input.acceleration);
	
	}

	public void MoveText()
	{
		if(bloodText!=null)
		{
			bloodText.transform.position = Camera.main.WorldToScreenPoint (transform.position);
			bloodText.GetComponent<Text>().color=new Color(GetComponent<BloodType>().bloodStickiness,0f,0f);
		}

		gameObject.GetComponent<BoxCollider> ().size = new Vector3 (bloodText.GetComponent<Text> ().fontSize / 80f * 2.84f, bloodText.GetComponent<Text> ().fontSize / 80f * 0.608f);
	} 
}
