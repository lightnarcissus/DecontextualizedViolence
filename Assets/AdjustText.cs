using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustText : MonoBehaviour {

	public GameObject bloodText;
	public float movementScale=1f;
	private Rigidbody rBody;
	private float rotateBody=0f;
	private Vector3 pos;

	private bool couldBeSwipe=false;
	private Vector2 startPos;
	private float minSwipeDist;
	private float maxSwipeTime;
	private float swipeTime;
	private float startTime;
	private float comfortZone;

	public static float swipeDir;
	// Use this for initialization
	void Start () {
		rotateBody = Random.Range (0f, 360f);
		rBody = GetComponent<Rigidbody> ();
		InvokeRepeating ("MoveText", 0.01f, 0.1f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


//		if (Input.touchCount > 0) {
//			Touch touch = Input.touches [0];
//			
//			switch (touch.phase)
//			{
//			case TouchPhase.Began:
//				couldBeSwipe = true;
//				startPos = touch.position;
//				startTime = Time.time;
//				break;
//				
//			case TouchPhase.Moved:
//				couldBeSwipe = false;
//				break;
//				
//			case TouchPhase.Stationary:
//				couldBeSwipe = false;
//				break;
//				
//			case TouchPhase.Ended:
//				var swipeTime = Time.time - startTime;
//				var swipeDist = (touch.position - startPos).magnitude;
//
//
//				//Debug.Log ("tou
//				if(!couldBeSwipe)
//					swipeDir=(touch.position - startPos).magnitude;
//
////				if (couldBeSwipe (swipeTime < maxSwipeTime) (swipeDist > minSwipeDist)) {
////					// It's a swiiiiiiiiiiiipe!
////					var swipeDirection = Mathf.Sign (touch.position.y - startPos.y);
////					
////					// Do something here in reaction to the swipe.
////				}
//				break;
//			default:
//				break;
//			}
//		}

		pos = transform.position;
		pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * movementScale;
		rBody.AddForce(Input.acceleration);
		//Input.touches.
	
	}

	public void MoveText()
	{
		if(bloodText!=null)
		{
			bloodText.transform.position = Camera.main.WorldToScreenPoint (transform.position);
			bloodText.transform.eulerAngles=new Vector3(0f,0f,rotateBody);
			bloodText.GetComponent<Text>().color=new Color(GetComponent<BloodType>().bloodStickiness,0f,0f);
		}

		gameObject.GetComponent<BoxCollider> ().size = new Vector3 (bloodText.GetComponent<Text> ().fontSize / 80f * 2.84f, bloodText.GetComponent<Text> ().fontSize / 80f * 0.608f);
	} 
}
