using UnityEngine;
using System.Collections;

public class MoveOnClick : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;
	public GameObject camObj;
	public LayerMask mask;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		ray = camObj.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction);
		if(Physics.Raycast(ray,out hit,mask.value))
		{
			Debug.Log ("hi");
		}
	}
}
