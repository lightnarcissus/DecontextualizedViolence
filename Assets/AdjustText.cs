using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustText : MonoBehaviour {

	public GameObject bloodText;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("MoveText", 1f, 0.1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveText()
	{
		if(bloodText!=null)
			bloodText.transform.position = Camera.main.WorldToScreenPoint (transform.position);
	}
}
